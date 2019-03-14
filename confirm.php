<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>审查新用户</title>
    <style>
        body {
            font-family: "Microsoft YaHei";
        }

        .notice {
            font-size: 15px;
            color: red;
            text-align: center;
        }

        table {
            border-collapse: collapse;
            width: 100%;
            font-size: 18px;
        }

        table,
        th,
        td {
            border: 1px solid black;
        }

        .center {
            text-align: center;
        }

        .left {
            text-align: left;
            font-size: 15px;
        }

        a {
            text-decoration: none;
            color: #000;
        }
    </style>
</head>

<body>
    <div class="center">
        <?php
    //error_reporting(E_ALL^E_NOTICE);
        require "mysql.php";

        if ($_GET['type'] != "" && $_GET['id'] != "") {
            if ($_GET['type'] == "confirm") {
                $result = $con->query("UPDATE im_userinfo SET confirm = '1' WHERE id='" . $_GET["id"] . "'");
                if ($result) {
                    $set = $con->query("UPDATE im_system SET userinfo=userinfo+1  WHERE id='1'");
                    echo '<p>已确认ID：' . $_GET['id'] . ' 的用户注册请求</p>';
                } else {
                    echo '<p>确认操作失败，请重试</p>';
                }
            } else if ($_GET['type'] == "delte") {
                $result = $con->query("UPDATE im_userinfo SET back = '1' WHERE id='" . $_GET["id"] . "'");
                if ($result) {
                    $set = $con->query("UPDATE im_system SET userinfo=userinfo+1  WHERE id='1'");
                    echo '<p>已删除ID：' . $_GET['id'] . ' 的用户注册请求</p>';
                } else {
                    echo '<p>删除操作失败，请重试</p>';
                }
            } else {
                echo '<p>操作错误，请重试</p>';
            }
        }
        ?>
        <table border="1">
            <tr>
                <th class="left">用户名</th>
                <th class="left">操作</th>
            </tr>
            <?php
            $result = $con->query("SELECT * FROM im_userinfo WHERE back = '0' AND confirm = '0'");
            if ($result->fetch_array() == null) {
                echo '<p>暂无需要审批的新注册用户。</p>';
            }
            $result = $con->query("SELECT * FROM im_userinfo WHERE back = '0' AND confirm = '0'");
            while ($row = $result->fetch_array()) {

                echo '<tr>
                    <td class="left">' . $row['username'] . '</td>
                    <td class="left"><a href="?type=confirm&id=' . $row['id'] . '">通过</a> | <a href="?type=delte&id=' . $row['id'] . '"><span class="notice">删除</span></a></td>
                </tr>';
            }
            ?>
        </table>
    </div>
</body>

</html> 