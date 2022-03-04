using SDL2;

namespace Calculator
{
    public class Calculator
    {
        static void Main()
        {
            Application app = new Application();
            app.Init("Calculator", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 300, 500);
            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            rect.x = rect.y = 0;
            rect.h = rect.w = 64;
            app.CreateNewComponent(ComponentID.BUTTON_0, ComponentType.COMPONENT_BUTTON, "assets/button0.png", rect, rect);
            app.Run();
        }
    }
}
