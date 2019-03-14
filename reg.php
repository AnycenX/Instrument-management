<?php
//error_reporting(E_ALL^E_NOTICE);
require "mysql.php";

echo '<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>注册新用户</title>
    <style>
        body {
            font-family: "Microsoft YaHei";
        }
        
        .form-input {
            font-size: 13px;
            width: 198px; 
            height: 25px;
            border-width:1px;
            border-color:black;
        }

        .form-btn {
            font-size: 13px;
            width: 200px;
            height: 32px;
            color: #fff;
            background-color:#0067b8;
            border-width:0;
            cursor:pointer;
        }

        .notice {
            font-size: 13px;
            color: red;
            text-align: center;
        }
    </style>
</head>

<body bgcolor="#f0f0f0">
    <form method="POST">
        <table>
            <input type="hidden" name="type" value="reg" />
            <tr>
                <td><input type="text" class="form-input" name="user" placeholder="&nbsp;请输入用户名" value="'.$_POST["user"].'" /></td>
            </tr>
            <tr>
                <td><input type="password" class="form-input" name="pass" placeholder="&nbsp;请输入密码" value="'.$_POST["pass"].'" /></td>
            </tr>
            <tr>
                <td><input type="password" class="form-input" name="repass" placeholder="&nbsp;请输确认密码" value="'.$_POST["repass"].'" /></td>
            </tr>';

            if($_POST["type"] == "reg")
            {
                if($_POST["user"]=="")
                {
                    echo '<tr>
                    <td><span class="notice">请输入用户名</span></td>
                    </tr>';
                }
                else if(strlen($_POST["user"])<4)
                {
                    echo '<tr>
                    <td><span class="notice">用户名长度应大于4</span></td>
                    </tr>';
                }
                else if($_POST["pass"]=="")
                {
                    echo '<tr>
                    <td><span class="notice">请输入密码</span></td>
                    </tr>';
                }
                else if(strlen($_POST["pass"])<6)
                {
                    echo '<tr>
                    <td><span class="notice">密码长度应大于6</span></td>
                    </tr>';
                }
                else if($_POST["pass"] != $_POST["repass"])
                {
                    echo '<tr>
                    <td><span class="notice">两次输入密码不一致</span></td>
                    </tr>';
                }
                else
                {
                    $result = $con->query("SELECT * FROM im_userinfo WHERE username = '".$_POST["user"]."' AND back = '0'");
                    if($result->fetch_array()!=null)
                    {
                        echo '<tr>
                        <td><span class="notice">用户名已经存在</span></td>
                        </tr>';
                    }
                    else
                    {
                        $passsalt = substr(md5(uniqid(microtime(true),true)),0,6);
                        $password = md5($_POST["pass"].$passsalt);
                        $result = $con->query("INSERT INTO im_userinfo VALUES ('', '1', '".$_POST["user"]."', '".$password."', '".$passsalt."', '0', '0', '0')");
                        if($result)
                        {
                            $set = $con->query("UPDATE im_system SET userinfo=userinfo+1  WHERE id='1'"); 
                            echo '<tr>
                            <td><span class="notice">注册成功，请等待管理员审核</span></td>
                            </tr>';
                        }
                        else
                        {
                            echo '<tr>
                            <td><span class="notice">系统错误</span></td>
                            </tr>';
                        }
                    }
                }
            }

            echo'<tr>
                <td><br><input type="submit" class="form-btn" value="立即注册" /></td>
            </tr>
        </table>
    </form>
</body>

</html>';


