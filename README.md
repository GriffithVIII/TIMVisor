# Contents
- [TIMVisor](#timvisor)
- [Dependecies](#dependecies)
- [TIM Format](#tim-format)
  * [CLUT](#clut)
  * [BPP](#bpp)
- [To-Do List](#to-do-list)

# TIMVisor
TIMVisor is a converter for the PlayStation 1 TIM graphics format. It has support for 4BPP, 8BPP, 16BPP and 24BPP, as well as an exporter and importer in .PNG and .TIM formats.

![image](https://user-images.githubusercontent.com/51249452/234389718-f056230a-1d09-48d3-b165-ece5e62abc45.png)

# Dependecies
The runtime .NET 6.0 is required to run.
[.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

# TIM Format
The TIM files are uncompressed raster images handled by the PlayStation unit, and can be transferred directly to its VRAM.

## CLUT
CLUT stands for `Color LookUp Table`, in short, it is a color palette.

## BPP
BPP stands for `Bits Per Pixel`, it denotes the number of bits per pixel. The TIM format supports the following types:

- 4BPP
- 8BPP
- 16BPP
- 24BPP

# To-Do List

- Transparent color picker (in most cases black).
- Support for multi-Blocks CLUT.
- Palette preservation.
- Being able to change the background color for transparent colors.
