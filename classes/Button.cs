using SDL2;

namespace Calculator
{
    public class Button : Component, IVisible
    {
        public void Render(object? sender, RenderEventArgs e)
        {
            SDL.SDL_RenderCopy(renderer, texture, ref srcRect, ref destRect);
        }
        public Button(IntPtr texture, IntPtr renderer, SDL.SDL_Rect srcRect, SDL.SDL_Rect destRect)
        {
            this.texture = texture;
            this.renderer = renderer;
            this.srcRect = srcRect;
            this.destRect = destRect;
        }
    }
}