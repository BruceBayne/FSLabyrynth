using System.Globalization;
using System.Runtime.CompilerServices;
using SDL2;

namespace Labyrynth.CSharp;

public static class GameWindow
{
	private static IntPtr renderer;
	private static IntPtr window;


	public static void Rect(int x, int y, int width, int height)
	{
		SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 0);
		SDL.SDL_Rect rectangle;
		rectangle.x = x;
		rectangle.y = y;
		rectangle.w = width;
		rectangle.h = height;


		SDL.SDL_RenderDrawRect(renderer, ref rectangle);
		//SDL.SDL_RenderFillRect(renderer, ref rectangle);
	}

	public static void DrawPixel()
	{
		//SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 0);
		//SDL.SDL_RenderDrawLine(renderer, 320, 200, 300, 240);
		//SDL.SDL_RenderDrawLine(renderer, 300, 240, 340, 240);
		//SDL.SDL_RenderDrawLine(renderer, 340, 240, 320, 200);
		//SDL.SDL_FillRect()
	}

	public static void DrawLine()
	{
		SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 0);
		SDL.SDL_RenderDrawLine(renderer, 320, 200, 300, 240);
		SDL.SDL_RenderDrawLine(renderer, 300, 240, 340, 240);
		SDL.SDL_RenderDrawLine(renderer, 340, 240, 320, 200);


		//SDL_SetRenderDrawColor(renderer, 0, 255, 0, 0);
		//for (int x = 0; x < 1000; x++)
		//	SDL_RenderDrawPoint(renderer, x, x);


		//SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);


		//SDL_Rect rectangle;
		//rectangle.x = 0;
		//rectangle.y = 0;
		//rectangle.w = 50;
		//rectangle.h = 50;
		//SDL_RenderFillRect(renderer, ref rectangle);
	}

	public static void Go(Action onFrameRender)
	{
		SDL.SDL_SetHint(SDL.SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING, "1");
		if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) == 0)
		{
			if (SDL.SDL_CreateWindowAndRenderer(1600, 800, 0, out window, out renderer) == 0)
			{
				while (true)
				{
					var startTime = SDL.SDL_GetTicks();
					SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 0);
					SDL.SDL_RenderClear(renderer);
					onFrameRender();
					GameWindow.DrawLine();
					SDL.SDL_RenderPresent(renderer);
					SDL.SDL_RenderFlush(renderer);

					var frameTime = SDL.SDL_GetTicks() - startTime;
					var fps = frameTime > 0 ? 1000.0f / frameTime : 0.0f;

					SDL.SDL_SetWindowTitle(window, $"FPS: [{fps.ToString(CultureInfo.InvariantCulture)}]");

					SDL.SDL_PollEvent(out var e);
				}

				SDL.SDL_DestroyRenderer(renderer);

				SDL.SDL_DestroyWindow(window);
			}

			SDL.SDL_Quit();
		}
	}
}