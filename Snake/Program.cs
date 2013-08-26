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
	public static class MainClass
	{
		public static void Main(string[] args)
		{
			Console.SetWindowSize(256, 192);
			GameInfo info = new GameInfo() { Exit = false, Snake = new Snake(), StartTime = DateTime.Now };
			Timer gameTimer = new Timer(new TimerCallback(GameUpdate), info, 0, 100);

			while (!info.Exit)
				Thread.Sleep(100);

			gameTimer.Dispose();
		}

		private static void GameUpdate(Object stateInfo)
		{
			GameInfo info = stateInfo as GameInfo;

			// Update direction
			if (Console.KeyAvailable) {
				ConsoleKeyInfo cki = Console.ReadKey(true);
				if (cki.Key == ConsoleKey.LeftArrow)
					info.Snake.Direction = "Left";
				else if (cki.Key == ConsoleKey.RightArrow)
					info.Snake.Direction = "Right";
				else if (cki.Key == ConsoleKey.UpArrow)
					info.Snake.Direction = "Up";
				else if (cki.Key == ConsoleKey.DownArrow)
					info.Snake.Direction = "Down";
			}

			// Refresh each second
			if ((DateTime.Now - info.StartTime).Milliseconds % 1000 < 100) {
				Console.Clear();
				info.Snake.Update();
				info.Exit = info.Snake.IsDead;
			}
		}
	}

	public class GameInfo
	{
		public Snake Snake {
			get;
			set;
		}

		public DateTime StartTime {
			get;
			set;
		}

		public bool Exit {
			get;
			set;
		}
	}
}
