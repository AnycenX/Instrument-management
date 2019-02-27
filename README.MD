# Instrument Management #

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

#### 表1 获取基础信息 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=start|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态|
|update|Int|5|软件主体最新版本号|
|userinfo|Int|5|用户列表最新版本号|
|processinfo|Int|5|监控进程列表最新版本号|

返回示例

    {
        "code": 200,
        "data": {
            "update": 5,
            "userinfo": 5,
            "processinfo": 5
        }
    }

#### 表2 获取软件更新信息 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=update|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|version|String|是|软件版本号|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|是否存在更新|
|file|List|列表|更新文件列表|
|+name|String|main.exe|更新文件名|
|+url|String|https://soft.jsdrv.com/|更新文件URL|

返回示例

    {
        "code": 200,
        "data": [{
            "name": "main.exe",
            "url": "https://soft.jsdrv.com/"
        }, {
            "name": "nude.dll",
            "url": "https://soft.jsdrv.com/"
        }]
    }

#### 表3 获取用户列表更新信息 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=userinfo|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|version|String|是|用户列表版本号|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|是否存在更新|
|list|List|列表|更新文件列表|
|+username|String|admin|用户名|
|+passwoed|String|21232f297a57a5a743894a0e4a801fc3|密码（MD5）|
|+passsalt|String|6ed6hf|密码加盐|

返回示例

    {
        "code": 200,
        "data": [{
            "id": 1,
            "username": "anycen",
            "passwoed": "21232f297a57a5a743894a0e4a801fc3",
            "passsalt": "6ed6hf"
        }, {
            "id": 2,
            "username": "admin",
            "passwoed": "21232f297a57a5a743894a0e4a801fc3",
            "passsalt": "dfe3sd"
        }]
    }

#### 表4 获取监控进程列表更新信息 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=processinfo|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|version|String|是|监控进程列表版本号|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|是否存在更新|
|list|List|列表|监控进程文件列表|
|+name|String|软件名称1|监控软件名|
|+process|String|tasges|监控进程名|
|+type|String|exe|监控进程类型|


返回示例

    {
        "code": 200,
        "data": [{
            "name": "软件名称1",
            "process": "tasges",
            "type": "exe"
        }, {
            "name": "软件名称2",
            "process": "dsp",
            "type": "msi"
        }]
    }

#### 表5 日志上传接口 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=uplog|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|username|String|是|用户名|
|name|String|是|软件名|
|process|String|是|进程名|
|timestart|Longint|是|起时间 时间戳|
|timestop|Longint|是|止时间 时间戳|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态码|

返回示例

    {
        "code": 200,
        "data": "OK"
    }

## 二、管理端 ##

### 管理端需要保证以下几个功能 ###

1、拥有权限管理功能  
2、保证可以推送用户信息  
3、保证可以推送监控列表信息  
4、保证可以获取日志信息
5、在公网失效的情况下，尽量保证局域网通信服务  

### 管理端所需要的功能 ###

1、使用账户密码登录  
2、新建、编辑、删除用户账户及密码  
3、新建、编辑、删除监控列表信息  
4、显示并统计使用日志信息  
5、局域网服务端，广播信息  
6、启动时作为暂存服务，以便其他用户端拉取信息  
7、局域网属于备用手段，目的是在公网无法连接时，完成基本数据更新  

### 管理端数据接口 ###

#### 表1 用户信息上传接口 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=inuser|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|username|String|是|用户名|
|password|String|是|用户密码（MD5）|
|passsalt|String|是|密码加盐|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态码|

返回示例

    {
        "code": 200,
        "data": "OK"
    }

#### 表2 用户信息更新接口 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=upuser|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|username|String|是|用户名|
|password|String|是|用户密码（MD5）|
|passsalt|String|是|密码加盐|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态码|

返回示例

    {
        "code": 200,
        "data": "OK"
    }

#### 表3 监控进程列表上传接口 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=inprocess|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|name|String|是|监控软件名|
|process|String|是|监控进程名|
|potype|String|是|监控进程类型（EXE、MSI等）|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态码|

返回示例

    {
        "code": 200,
        "data": "OK"
    }

#### 表4 监控进程列表更新接口 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=upprocess|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|name|String|是|监控软件名|
|process|String|是|监控进程名|
|potype|String|是|监控进程类型（EXE、MSI等）|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态码|

返回示例

    {
        "code": 200,
        "data": "OK"
    }

#### 表5 获取监控日志接口 ####

|功能|接口|
|----|----|
|HTTP 请求方式|GET|
|URL|https://api.anycen.com/instrument/?type=getlog|

请求参数  

|参数名称|类型|是否必须|描述|
|----|----|----|----|
|type|String|是|操作类型|
|timestamp|Longint|是|时间戳|
|key|String|是|authkey与时间戳计算值|
|name|String|是|监控软件名|
|timestart|Longint|是|起时间 时间戳|
|timestop|Longint|是|止时间 时间戳|

返回参数  

|参数名称|类型|示例值|描述|
|----|----|----|----|
|code|String|200|状态码|
|date|List|列表|返回列表|
|+username|string|admin|用户名|
|+name|string|tasges|软件名|
|+timestart|Longint|12345|进程开始运行时间戳|
|+timestop|Longint|12345|进程结束运行时间戳|

返回示例

    {
        "code": 200,
        "date": [{
            "username": "admin",
            "name": "tasges",
            "timestart": "12345",
            "timestop": "12345"
        }, {
            "username": "admin",
            "name": "tasges",
            "timestart": "12345",
            "timestop": "12345"
        }]
    }

部分SQL语句  

    UPDATE `category` SET `arrchildid`=TRIM(BOTH ',' FROM replace(concat(',',`arrchildid`,','), ',1,', '')) WHERE `catid`=100