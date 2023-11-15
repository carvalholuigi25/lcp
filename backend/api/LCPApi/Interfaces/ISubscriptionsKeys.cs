using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ISubscriptionsKeys {
    Task<ActionResult<IEnumerable<SubscriptionsKeys>>> GetSubscriptionsKeys();
    Task<ActionResult<SubscriptionsKeys>> GetSubscriptionsKeysById(int id);
    Task<IActionResult> PutSubscriptionsKeys(int id, SubscriptionsKeys SubscriptionsKeys);
    Task<ActionResult<SubscriptionsKeys>> PostSubscriptionsKeys(SubscriptionsKeys SubscriptionsKeys);
    Task<IActionResult> DeleteSubscriptionsKeys(int id);
}