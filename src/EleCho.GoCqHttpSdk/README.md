<div align="center">
<img src="logo.png" width="200"/>

# EleCho.GoCqHttpSdk

_✨ 专为 [Go-CqHttp](https://github.com/Mrs4s/go-cqhttp) 打造的, 便捷与优雅的通信 SDK ✨_

[![LICENSE](https://img.shields.io/github/license/EleChoNet/EleCho.GoCqHttpSdk)](/LICENSE)
[![nuget](https://img.shields.io/nuget/vpre/EleCho.GoCqHttpSdk)](https://www.nuget.org/packages/EleCho.GoCqHttpSdk)
[![nuget](https://img.shields.io/nuget/dt/EleCho.GoCqHttpSdk)](https://www.nuget.org/packages/EleCho.GoCqHttpSdk)

[文档](https://github.com/OrgEleCho/EleCho.GoCqHttpSdk/wiki) ·
[下载](https://www.nuget.org/packages/EleCho.GoCqHttpSdk) ·
[唠嗑](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=ddli6snqppDk4HFKgKEph7QF_8qL_OJc&authKey=ze5fTRuRc%2BvdCrhLJLasAe0wnZ2YUMiuyKgLMl2jTcGQHtGSYIniu9%2BAAdNq76Fb&noverify=0&group_code=696327017) ·
[参与贡献](https://github.com/OrgEleCho/EleCho.GoCqHttpSdk/wiki/9.-%E8%B4%A1%E7%8C%AE)

</div>

<br/><br/>

## 📖 简介:

虽然有很多的 OneBot 通信 SDK, 但没有一个是专为 `go-cqhttp` 打造的 .NET SDK. 秉持着 C# 的优雅开发理念, 这个库诞生了.

用户可以享受到完全遵守 C# 编码风格, 高度封装的各种接口, 以及优化过命名的接口, 事件, 数据成员, 枚举类型等.

> 如果你不了解 `go-cqhttp`, 可以从这里了解一下: [go-cqhttp 文档](https://docs.go-cqhttp.org/) / [go-cqhttp 仓库](https://github.com/Mrs4s/go-cqhttp)

## 🚀 兼容:

EleCho.GoCqHttpSdk 是专为 Go-CqHttp 打造的, 而 Go-CqHttp 又遵循 OneBot11 协议, 所以 EleCho.GoCqHttpSdk 基本也是兼容 OneBot11 的.

## ✨ 支持

连接协议:

  - [x] 正向 HTTP (CqHttpSession, 发送操作)
  - [x] 反向 HTTP (CqRHttpSession, 接收上报)
  - [x] 正向 WebSocket (CqWsSession, 发送操作与接收上报)
  - [x] 反向 WebSocket (CqRWsSession, 发送操作与接收上报)

消息格式:

  - [x] 字符串 (CQ 码, 支持解析 CQ 码)
  - [x] 数组 (JSON, 支持解析 JSON 格式消息)


## 📎快速开始

转到 Wiki 页面以查阅文档: [EleCho.GoCqHttpSdk Wiki](https://gihub.com/OrgEleCho/EleCho.GoCqHttpSdk/wiki)