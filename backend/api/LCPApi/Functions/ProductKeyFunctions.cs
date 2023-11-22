using System.Text;
using System.Security.Cryptography;

namespace LCPApi.Functions;

public class ProductKeyClass {
	public Guid? Id { get; set; } = Guid.NewGuid();
	public string? SecretKey { get; set; }
	public string? PrivateKey { get; set; }
	public string? LicenseKey { get; set; }
	public string? Msg { get; set; }
	public bool? IsValid { get; set; }
	public DateTime? DateExp { get; set; }
	public DateTime? DateNow { get; set; }
}

public static class ProductKeyFunctions
{
    public async static Task<List<ProductKeyClass>> GetProductKey() {
        //src: https://dotnetfiddle.net/srGTKN
        //var secretKey = CreatePrivateKey();
		var secretKey = "+bCzRidhVxwx5TKpkz14nf5cL+BMH+ahZIOCy4bPVzdXWhysq+tZfOtrHsw9vdg5vKes/lVwzHIyquvmz9taDg==";
		var privateKey = CreatePrivateKey();
    	var licenseKey = CreateLicense(secretKey);
    	var isValid = ValidateLicense(licenseKey, secretKey);
		var validStatus = isValid ? "valid" : "invalid";
		Random rnd = new Random();
		            
		return await Task.FromResult(new List<ProductKeyClass>() {
            new ProductKeyClass() {
				Id = Guid.NewGuid(),
                SecretKey = secretKey,
				PrivateKey = privateKey,
                LicenseKey = licenseKey,
                Msg = $"This product license key is {validStatus}",
				IsValid = isValid,
				DateExp = DateTime.UtcNow.AddMonths(rnd.Next(1, 13)),
				DateNow = DateTime.UtcNow
            }
        });
    }

    static string CreatePrivateKey()
	{
		// Step 01: Create your private hashkey and store it on the database
		byte[] hashKey = GenerateRandomCryptographicBytes(64);

		// Convert the key to base64 so you can easily store it on the database.
		// This should be kept private and never leaves your control.
		var base64Secret = Convert.ToBase64String(hashKey);
		
		Console.WriteLine($"Private Key = {base64Secret}");

		return base64Secret;
	}
	
	static string CreateLicense(string secretKey)
	{
		// Generate a license key of 10 chars (split into groups of 5)
		var licenseKey = Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 15);

		Console.WriteLine($"licenseKey = {licenseKey}");

		// Generate a Hmac license using secretkey
		var storedHmacOnDB = CalculateHmac(licenseKey, secretKey).ToUpper();
		var HMACTruncated = storedHmacOnDB.Substring(0, 15);

		Console.WriteLine($"HMAC = {HMACTruncated}");

		var licenseAndHMAC = InsertHyphen($"{licenseKey}{HMACTruncated}");

		Console.WriteLine($"Final User License = {licenseAndHMAC}");

		return licenseAndHMAC;
	}
	
	static bool ValidateLicense(string licenseKey, string secretKey)
	{
		var tmp = licenseKey.Split('-');

		var license = $"{tmp[0]}{tmp[1]}{tmp[2]}";
		var licenseHmac = $"{tmp[3]}{tmp[4]}{tmp[5]}";

		string calculatedHmac = CalculateHmac(license, secretKey);
		var HMACTruncated = calculatedHmac.ToUpper().Substring(0, 15);

		bool isValid = licenseHmac.Equals(HMACTruncated, StringComparison.OrdinalIgnoreCase);

		return isValid;
	}
	
	static string InsertHyphen(string input, int everyNthChar = 5)
	{
		var sb = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			sb.Append(input[i]);
			if ((i + 1) % everyNthChar == 0 && i != input.Length - 1)
			{
				sb.Append("-");
			}
		}
		return sb.ToString();
	}
	
	static byte[] GenerateRandomCryptographicBytes(int keyLength)
	{
		byte[] key = new byte[64];
		using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
		{
			rng.GetBytes(key);
		}
		return key;
	}
	
	static string CalculateHmac(string data, string hashKeyBase64)
	{
		var byteArray = Convert.FromBase64String(hashKeyBase64);
		return CalculateHmac(data, byteArray);
	}

	static string CalculateHmac(string data, byte[] hashKey)
	{
		var hmac = new HMACMD5(hashKey);
		byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
		return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
	}
}