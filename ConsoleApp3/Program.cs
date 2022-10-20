using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurceMaze
{
	class Program
	{
		//пошук шляху головна функція
		static void FindWay(int X, int Y, int[,] mase,ref int[] arrX,ref int[] arrY)
		{
			//якщо при виклику рекурсії ми вже на виході то виводимо попередні кроки і кінець
			if (mase[X, Y] == 9)
			{
				for (int i = 0; i < arrX.Length; i++)
				{
					Console.Write("step ");
					Console.Write(i+1);
					Console.Write(": (");
					Console.Write(arrX[i]);
					Console.Write(", ");
					Console.Write(arrY[i]);
					Console.Write(");\n");
				}
				System.Environment.Exit(0);
			}
			//перетворюємо місце на якому стоїмо в стінку
			mase[X,Y] = 1;
			if (mase[X - 1,Y] == 0 || mase[X - 1,Y] == 9)
			{
				//додаємо Х на останній елемент Х-1 це те що запишемо в шлях
				AddLastX(ref arrX,X - 1);
				AddLastY(ref arrY,Y);
				//викликаємо рекурсію і передаємо крок вліво
				FindWay(X - 1, Y, mase, ref arrX, ref arrY);
			}
			if (mase[X + 1,Y] == 0 || mase[X + 1,Y] == 9)
			{
				AddLastX(ref arrX, X + 1);
				AddLastY(ref arrY, Y);
				FindWay(X + 1, Y, mase, ref arrX, ref arrY);
			}
			if (mase[X,Y - 1] == 0 || mase[X,Y - 1] == 9)
			{
				AddLastX(ref arrX, X);
				AddLastY(ref arrY, Y - 1);
				FindWay(X, Y-1, mase, ref arrX, ref arrY);
			}
			if (mase[X,Y + 1] == 0 || mase[X,Y + 1] == 9)
			{
				AddLastX(ref arrX, X);
				AddLastY(ref arrY, Y + 1);
				FindWay(X, Y+1, mase,ref arrX, ref arrY);
			}
			//якщо ні 1 іф не спрацював значить ми себе закопали, отож видаляємо останній елемент з масивів виводушляху
			DelLastX(ref arrX);
			DelLastY(ref arrY);
		}
		//видалення останнього Х
		static void DelLastX(ref int[] arrX)
		{
			int[] newArr = new int[arrX.Length - 1];
			for (int i = 0; i < arrX.Length-1; i++)
			{
				newArr[i] = arrX[i];
			}
			arrX = newArr;
		}
		//видалення останнього Y
		static void DelLastY(ref int[] arrY)
		{
			int[] newArr = new int[arrY.Length - 1];
			for (int i = 0; i < arrY.Length - 1; i++)
			{
				newArr[i] = arrY[i];
			}
			arrY = newArr;
		}
		//додаємо Х в кінець
		static void AddLastX(ref int[] arrX, int Xo)
		{
			int[] newArr = new int[arrX.Length+1];
			newArr[newArr.Length-1] = Xo;
			for (int i = 0; i < arrX.Length; i++)
			{
				newArr[i] = arrX[i];
			}
			arrX = newArr;
		}
		//додаємо Y в кінець
		static void AddLastY(ref int[] arrY, int Yo)
		{
			int[] newArr = new int[arrY.Length + 1];
			newArr[newArr.Length - 1] = Yo;
			for (int i = 0; i < arrY.Length; i++)
			{
				newArr[i] = arrY[i];
			}
			arrY = newArr;
		}
		//перевірка чи ми не впали на стіну
		static void NotWall(string x, string y, int[,] mase)
		{
			Console.WriteLine('\n');
			Console.WriteLine("Enter start X");
			x = Console.ReadLine();
			Console.WriteLine("Enter start Y");
			y = Console.ReadLine();
			int Xo = Convert.ToInt32(x);
			int Yo = Convert.ToInt32(y);
			if (mase[Xo, Yo] == 0)
			{
				int[] arrX= {};
				int[] arrY= {};
				AddLastX(ref arrX, Xo);
				AddLastY(ref arrY, Yo);
				FindWay(Xo, Yo, mase,ref arrX,ref arrY);
			}
			else
			{
				Console.WriteLine("WALL LOOK AT THE MAZE AND TRY AGAIN");
				Console.WriteLine();
				Xo = 0;
				Yo = 0;
				//якщо попали в стінку то пропонуємо ввести людині стартові координати поки не попадемо в 0
				NotWall(x, y, mase);
			}
		}
		static void Main(string[] args)
		{
			int[,] mase = new int[8, 8]{
		 { 1, 1, 1, 1, 1, 1, 1, 1 },
		 { 1, 0, 0, 1, 0, 1, 0, 1 },
		 { 1, 1, 0, 0, 0, 1, 0, 1 },
		 { 1, 0, 0, 1, 0, 0, 0, 1 },
		 { 1, 0, 1, 0, 0, 1, 1, 1 },
		 { 1, 1, 1, 1, 0, 0, 0, 1 },
		 { 1, 9, 0, 0, 0, 1, 1, 1 },
		 { 1, 1, 1, 1, 1, 1, 1, 1 },
	};
			for (int i = 0; i < 8; i++)
			{
				Console.WriteLine();
				for (int u = 0; u < 8; u++)
				{
					Console.Write(mase[i, u]+" ");
				}
			}
			string x = "", y = "";
			NotWall(x, y, mase);
		}
	}
}

 