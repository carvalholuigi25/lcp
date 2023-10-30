<?php 
    if(isset($_POST["btnsubContact"])) 
    {
        $name = $_POST["name"];
        $email = $_POST["email"];
        $subject = $_POST["subject"];
        $message = $_POST["message"];

        $from = $email;
        $to = "luiscarvalho239@gmail.com";
        $headers = "From: " . $from . "rn";

        if(filter_var($email, FILTER_VALIDATE_EMAIL))
        {
            if (mail($to, $subject, $message, $headers, "-f " . $from))
            {
                echo 'Sended mail to ' . $to . '!';
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