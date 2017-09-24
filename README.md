# DirectX Renderer

## Introduction

DirectX Renderer is a series of programs in .NET using SharpDX, wrapper of the DirectX API (native C++),
designed to help with functions like Overlay text non-hooked, quickly image capture and other hooked options.

## Overlay (Non-Hooked method)
Some times you might need a method to write over the screen without using hooks, for example to skip a VAC of a game, because hooks may become detectable in the future, so a solution is an external solution.

How works?
The overlay is a hidden transparent windows renderer on the top, allowing interact with other windows, this form is invisible, don't appear in Alt-tab window or taskbar. You can use a basic windows-form objects or draw direct using DirectX functions.

Tested on Windows 7 (64bits) / Windows 10 (64 bits)

Example Overlay Text and Image:

![alt text](https://raw.githubusercontent.com/DoxCode/DirectX_Renderer/594b35de2ea95043fd5799809c7e11300f68fae3/_git_images/Overlay.png)

## License
License under MIT License.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
