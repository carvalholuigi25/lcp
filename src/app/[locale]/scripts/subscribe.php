<?php 
    if(isset($_POST["btnsubSubscribe"])) 
    {
        $email = $_POST["email"];
        $from = $email;
        $to = "luiscarvalho239@gmail.com";
        $headers = "From: " . $from . "rn";

        $subject = "LCP - New subscription";
        $body = "LCP - New user subscription: " . $email;

        if(filter_var($email, FILTER_VALIDATE_EMAIL))
        {
            if (mail($to, $subject, $body, $headers, "-f " . $from))
            {
                echo 'Your e-mail (' . $email . ') has been added to our mailing list!';
            }
            else
            {
                echo 'There was a problem with your e-mail (' . $email . ')';
            }
        }
        else
        {
            echo 'Your email isnt valid. Try in this format, like: [youremailname]@[domain].[extension (e.g: com)]';
        }
    }
?>