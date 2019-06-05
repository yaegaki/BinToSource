# BinToSource
Binary to C# code.

# Requirements

* .NET Core 3.0

## Build

```sh
$ git clone https://github.com/yaegaki/BinToSource.git
$ cd BinToSource
$ dotnet build -c release
```

## Usage

```sh
# create sample file
$ echo "hello, world" > hoge.txt

# sample file to C# code
$ dotnet BinToSource.dll Hoge hoge.txt > hoge.txt.cs
```

* input file(*hoge.txt*)

```txt:hoge.txt
hello, world
```

* output file(*hoge.txt.cs*)

```cs
namespace Hoge 
{
    partial class R
    {
        public static readonly byte[] hoge_txt = new byte[]
        {
104,101,108,108,111,44,32,119,111,114,108,100,
        };
    }
}
```
