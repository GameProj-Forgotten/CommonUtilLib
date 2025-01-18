# Introduction
CommonUtilLib is a basic library that aims to collect basic utilities commonly used throughout the Forgotten project.

Please note that this library is built based on .Net Framework 4.8.

<br><br>
<div align="center">
  <img src="https://github.com/user-attachments/assets/9f2e8c0d-7701-4050-ae0e-4d59992ec7b6" width="20%">
</div>
<br><br>

The representative functions provided by this library are as follows:
```
CommonUtilLib
└── ThreadSafe
    └── class SingleTon<_T> : IDisposable where _T : class, IDisposable, new()
    └── class SingleTonForGameObject<_T> where _T : MonoBehaviour
```