using SDL2;

namespace Calculator
{
    public class Field : Component, IVisible, IWritable
    {
        public void Render(object? sender, RenderEventArgs e)
        {
            SDL.SDL_RenderCopy(renderer, messageTexture, ref srcRect, ref destRect);
        }
        public void Write(string text, string fontPath)
        {
            message = text;
            var font = SDL_ttf.TTF_OpenFont(fontPath, 32);
            //Console.WriteLine(fontPath);
            var color = new SDL.SDL_Color();
            color.r = 0;
            color.g = 0;
            color.b = 0;
            color.a = 255;
            var tempSurf = SDL_ttf.TTF_RenderText_Solid(font, message, color);
            destRect.w = srcRect.w = message.Length * 19;
            destRect.h = srcRect.h = 32;
            
            messageTexture = SDL.SDL_CreateTextureFromSurface(renderer, tempSurf);
            //SDL.SDL_FreeSurface(tempSurf);
        }
        public Field(IApplication parent, IntPtr renderer, SDL.SDL_Rect srcRect, SDL.SDL_Rect destRect, IntPtr? texture = null) : base(parent)
        {
            this.texture = texture;
            this.renderer = renderer;
            this.srcRect = srcRect;
            this.destRect = destRect;
            this.parent = parent;
            parent.Render += Render;
        }
        protected string message = "";
        protected IntPtr messageTexture;
    }
}