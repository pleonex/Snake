// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="none">
// Copyright (C) 2013
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by 
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful, 
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details. 
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see "http://www.gnu.org/licenses/". 
// </copyright>
// <author>pleoNeX</author>
// <email>benito356@gmail.com</email>
// <date>26/08/2013</date>
// -----------------------------------------------------------------------
using System;
using System.Threading;

namespace Snake
{
	class MainClass
	{
		static int x = 0;
		static int y = 0;

		public static void Main(string[] args)
		{
			Console.SetWindowSize(256, 192);
			Timer timer = new Timer(new TimerCallback(Tick), null, 0, 1000);

			Console.ReadKey();
		}

		private static void Tick(object info)
		{
			Console.Clear();
			Console.SetCursorPosition(x, y);
			Console.Write("@");

			x += 1;
			if (x >= Console.WindowWidth) {
				y += 1;
				x = 0;
			}
		}
	}
}
