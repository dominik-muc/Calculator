using SDL2;

namespace Calculator
{
    public class Runtime
    {
        static void Main()
        {
            Application app = new Application();
            app.Init("Calculator", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 256, 384);

            app.CreateNewComponent
            (
                ComponentID.FIELD_0,
                ComponentType.COMPONENT_FIELD,
                NewRect(0, 0, 256, 32),
                NewRect(0, 0, 256, 32)
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_0,
                ComponentType.COMPONENT_BUTTON,      
                NewRect(0, 0, 64, 64),
                NewRect(0, 320, 64, 64),
                "assets/button0.png",
                SDL.SDL_Keycode.SDLK_0
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_1,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(0, 256, 64, 64),
                "assets/button1.png",
                SDL.SDL_Keycode.SDLK_1
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_2,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(64, 256, 64, 64),
                "assets/button2.png",
                SDL.SDL_Keycode.SDLK_2
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_3,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(128, 256, 64, 64),
                "assets/button3.png",
                SDL.SDL_Keycode.SDLK_3
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_4,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(0, 192, 64, 64),
                "assets/button4.png",
                SDL.SDL_Keycode.SDLK_4
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_5,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(64, 192, 64, 64),
                "assets/button5.png",
                SDL.SDL_Keycode.SDLK_5
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_6,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(128, 192, 64, 64),
                "assets/button6.png",
                SDL.SDL_Keycode.SDLK_6
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_7,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(0, 128, 64, 64),
                "assets/button7.png",
                SDL.SDL_Keycode.SDLK_7
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_8,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(64, 128, 64, 64),
                "assets/button8.png",
                SDL.SDL_Keycode.SDLK_8
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_9,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(128, 128, 64, 64),
                "assets/button9.png",
                SDL.SDL_Keycode.SDLK_9
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_CLEAR,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(0, 64, 64, 64),
                "assets/buttonCLEAR.png",
                SDL.SDL_Keycode.SDLK_DELETE
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_DEL,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(64, 64, 64, 64),
                "assets/buttonDEL.png",
                SDL.SDL_Keycode.SDLK_BACKSPACE
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_DIVIDE,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(192, 128, 64, 64),
                "assets/buttonDIVIDE.png",
                SDL.SDL_Keycode.SDLK_KP_DIVIDE
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_DOT,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(64, 320, 64, 64),
                "assets/buttonDOT.png",
                SDL.SDL_Keycode.SDLK_KP_PERIOD
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_EQ,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(128, 320, 64, 64),
                "assets/buttonEQ.png",
                SDL.SDL_Keycode.SDLK_KP_ENTER
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_MINUS,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(192, 256, 64, 64),
                "assets/buttonMINUS.png",
                SDL.SDL_Keycode.SDLK_KP_MINUS
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_PLUS,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(192, 320, 64, 64),
                "assets/buttonPLUS.png",
                SDL.SDL_Keycode.SDLK_KP_PLUS
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_POWER,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(192, 64, 64, 64),
                "assets/buttonPOWER.png",
                null
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_CHANGE,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(128, 64, 64, 64),
                "assets/buttonCHANGE.png",
                null
            );
            app.CreateNewComponent
            (
                ComponentID.BUTTON_TIMES,
                ComponentType.COMPONENT_BUTTON,
                NewRect(0, 0, 64, 64),
                NewRect(192, 192, 64, 64),
                "assets/buttonTIMES.png",
                SDL.SDL_Keycode.SDLK_KP_MULTIPLY
            );

            app.Run();
        }
        static SDL.SDL_Rect NewRect(int x, int y, int w, int h)
        {
            var rect = new SDL.SDL_Rect();
            rect.x = x;
            rect.y = y;
            rect.w = w;
            rect.h = h;
            return rect;
        }
    }
}
