// -----------------------------------------------------------------------
// <copyright file="Snake.cs" company="none">
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
using System.Collections.Generic;

namespace Snake
{
	public class Snake
	{
		//private static readonly char[] Head = { '→', '↑', '←', '↓' };
		private static readonly Dictionary<string, char> Head = new Dictionary<string, char>()
		{
			{ "Right", '→' }, { "Up", '↑' }, { "Left", '←' }, { "Down", '↓' }
		};

		public Snake()
		{
			this.Speed = 1;
			this.Position = new Point(0, 0);
			this.Direction = "Down";
			this.IsDead = false;
		}

		public bool IsDead {
			get;
			set;
		}

		public int Speed {
			get;
			set;
		}

		public Point Position {
			get;
			private set;
		}

		public string Direction {
			get;
			set;
		}

		public void Update()
		{
			this.UpdatePostion();
			if (!this.IsDead)
				Console.SetCursorPosition(this.Position.X, this.Position.Y);

			// Print snake
			Console.Write(Head[this.Direction]);
		}

		private void UpdatePostion()
		{
			Point pos = this.Position;
			switch (this.Direction) {
				case "Right": pos.X += this.Speed; break;
				case "Left":  pos.X -= this.Speed; break;
				case "Up":    pos.Y -= this.Speed; break;
				case "Down":  pos.Y += this.Speed; break;
			}
			this.Position = pos;

			// Check dead
			if (this.Position.X > Console.WindowWidth || 
				this.Position.X < 0 ||
				this.Position.Y < 0 ||
				this.Position.Y > Console.WindowHeight)
			{
				this.IsDead = true;
			}
		}
	}
}

