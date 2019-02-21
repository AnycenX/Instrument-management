## 一、客户端 ##

### 客户端需要保证以下几个功能 ###

1、保证在锁屏界面下，使用常规手段无法绕过锁屏操作部署终端  
2、保证在运行时记录部署终端中使用特定软件的时间  
3、保证在运行时不会被普通手段关闭或屏蔽  
4、保证可以获取最新的用户信息与监控进程列表  

### 客户端所需要的功能 ###

1、在登录界面后已管理员身份启动  
2、在锁屏界面中屏蔽任务管理器  
3、在锁屏界面中屏蔽各种快捷键（Ctrl+Alt+Del除外）  
4、在锁屏界面中或运行中强制关闭即可蓝屏重启（此项为可选）  
5、启动时首先检测是否连接公网，并获是否存在更新（包括软件更新，用户信息更新，监控列表更新）  
6、登录成功后最小化至托盘，并保留退出登录功能  
7、登录成功后根据监控列表监控进程，并记录日志发送至公网服务器  
8、局域网属于备用手段，目的是在公网无法连接时，完成基本数据更新  

### 客户端数据接口 ###

表1 获取基础信息

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/start/|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|timeset|String|是|时间戳|
|key|String|是|authkey与时间戳计算值|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|success|状态|
|update|Int|5|软件主体最新版本号|
|userinfo|Int|5|用户列表最新版本号|
|processinfo|Int|5|监控进程列表最新版本号|

返回示例

    {
        "code":"success",
        "update":5,
        "userinfo":5,
        "processinfo":5
    }

表2 获取软件更新信息

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/update/|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|timeset|String|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|version|String|是|软件版本号|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|success|是否存在更新|
|file|String|列表|更新文件列表|

返回示例

    {
        "code": "success",
        "file": [{
            "name": "main.exe"
        }, {
            "name": "nude.dll"
        }]
    }

表3 获取用户列表更新信息

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/userinfo/|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|timeset|String|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|version|String|是|用户列表版本号|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|success|是否存在更新|
|list|String|列表|更新文件列表|

返回示例

    {
        "code": "success",
        "list": [{
            "username": "anycen",
            "passwoed": "21232f297a57a5a743894a0e4a801fc3",
            "passsalt": "6ed6hf"
        }, {
            "username": "admin",
            "passwoed": "21232f297a57a5a743894a0e4a801fc3",
            "passsalt": "dfe3sd"
        }]
    }

表4 获取监控进程列表更新信息

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/processinfo/|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|timeset|String|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|version|String|是|监控进程列表版本号|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|success|是否存在更新|
|list|String|列表|监控进程文件列表|

返回示例

    {
        "code": "success",
        "list": [{
            "name": "软件名称1",
            "pocess": "tasges",
            "type": "exe"
        }, {
            "name": "软件名称2",
            "pocess": "dsp",
            "type": "dll"
        }]
    }

表5 日志上传接口

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/uplog/|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|timeset|String|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|username|String|是|用户名|
|pocess|String|是|进程名|
|start|Int|是|开始时间|
|time|Int|是|合计时间|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|success|是否存在更新|

返回示例

    {
        "code": "success"
    }