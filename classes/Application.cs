using SDL2;
using System.Runtime;

namespace Calculator
{
    public class Application : IApplication
    {
        private const string fontPath = "fonts/DroidSansMono.ttf";
        public Application()
        {

        }
        public void Init(string title, int x, int y, int w, int h)
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING); //todo: change flags to optimize
            SDL_ttf.TTF_Init();
            window = SDL.SDL_CreateWindow(title, x, y, w, h, 0);
            renderer = SDL.SDL_CreateRenderer(window, -1, 0);
        }
        public void Run()
        {
            uint a = SDL.SDL_GetTicks();
            uint b = SDL.SDL_GetTicks();
            double deltaTime = 0;
            isAlive = true;
            while(isAlive)
            {
                a = SDL.SDL_GetTicks();
                deltaTime = a - b;
                HandleEvents();
                if (deltaTime > 1000/30.0)
                {
                    //Console.WriteLine("fps: " + 1000 / deltaTime);

                    b = a;            
                    Update();
                }
            }
        }
        public void CreateNewComponent(ComponentID id, ComponentType type, SDL.SDL_Rect srcRect, SDL.SDL_Rect destRect, string texturePath = "", SDL.SDL_Keycode? activationKey = null)
        {
            switch(type)
            {
                case ComponentType.COMPONENT_BUTTON:
                    components.Add(id, new Button(this, id, activationKey, LoadTexture(texturePath), renderer, srcRect, destRect));
                    break;
                case ComponentType.COMPONENT_FIELD:
                    writableComponents.Add(id, new Field(this, renderer, srcRect, destRect));
                    break;
            }
        }
        public void Logic(ComponentID sender)
        {                                     
            switch(sender)
            {
                case ComponentID.BUTTON_0:
                    if(!error)
                        {
                        if(isDecimal)
                        {
                            decimalPoint++;
                        }
                        else
                        {
                            displayValue *= 10;                       
                        }
                        digits.Push(0);
                        currentOperation = Operation.ADD_NUMBER;
                    }
                    break;
                case ComponentID.BUTTON_1:
                    DigitHelper(1);
                    break;
                case ComponentID.BUTTON_2:
                    DigitHelper(2);
                    break;
                case ComponentID.BUTTON_3:
                    DigitHelper(3);
                    break;
                case ComponentID.BUTTON_4:
                    DigitHelper(4);
                    break;
                case ComponentID.BUTTON_5:
                    DigitHelper(5);
                    break;
                case ComponentID.BUTTON_6:
                    DigitHelper(6);
                    break;
                case ComponentID.BUTTON_7:
                    DigitHelper(7);
                    break;
                case ComponentID.BUTTON_8:
                    DigitHelper(8);
                    break;
                case ComponentID.BUTTON_9:
                    DigitHelper(9);
                    break;
                case ComponentID.BUTTON_CLEAR:
                    error = false;
                    decimalPoint = 0;
                    displayValue = 0;
                    storedValue = 0;
                    lastResult = 0;
                    lastOperation = Operation.EQUALS;
                    currentOperation = Operation.EQUALS;
                    digits.Clear();
                    break;
                case ComponentID.BUTTON_CHANGE:
                    if(!error)
                    {
                        try
                        {
                            displayValue *= -1;
                        }
                        catch { error = true; }
                        currentOperation = Operation.CHANGE;                   
                    }
                    break;
                case ComponentID.BUTTON_DEL:
                    if((digits.Count != 0) && currentOperation == Operation.ADD_NUMBER)
                    {
                        if(isDecimal)
                        {                            
                            displayValue -= (decimal)(digits.Pop()/(Math.Pow(10, decimalPoint-1)));
                            if(decimalPoint == 1) displayValue /= 10;
                            decimalPoint--;
                        }
                        else
                        {
                            displayValue -= digits.Pop();
                            displayValue /= 10;
                        }
                    }     
                    break;
                case ComponentID.BUTTON_DOT:
                    if(!error)
                        decimalPoint++;
                    break;
                case ComponentID.BUTTON_PLUS:
                    OperationHelper(Operation.PLUS);
                    break;
                case ComponentID.BUTTON_MINUS:
                    OperationHelper(Operation.MINUS);  
                    break;
                case ComponentID.BUTTON_TIMES:
                    OperationHelper(Operation.TIMES);
                    break;
                case ComponentID.BUTTON_DIVIDE:
                    OperationHelper(Operation.DIVIDE);
                    break;
                case ComponentID.BUTTON_POWER:
                    OperationHelper(Operation.POWER);
                    break;
                case ComponentID.BUTTON_EQ:
                    bool update = true;
                    if(!error)
                    {
                        try
                        {
                            switch(currentOperation)
                            {
                                case Operation.ADD_NUMBER:
                                case Operation.CHANGE:
                                    switch(lastOperation)
                                    {
                                        case Operation.PLUS:
                                            lastResult = storedValue + displayValue;
                                            storedValue = displayValue;
                                            lastOperation = Operation.PLUS;                        
                                            break;
                                        case Operation.MINUS:
                                            lastResult = storedValue - displayValue;
                                            storedValue = displayValue;
                                            lastOperation = Operation.MINUS;                        
                                            break;
                                        case Operation.TIMES:
                                            lastResult = storedValue * displayValue;
                                            storedValue = displayValue;
                                            lastOperation = Operation.TIMES;                        
                                            break;
                                        case Operation.DIVIDE:
                                            lastResult = storedValue / displayValue;
                                            storedValue = displayValue;
                                            lastOperation = Operation.DIVIDE;                        
                                            break;
                                        case Operation.POWER:
                                            lastResult = (decimal)Math.Pow((double)storedValue, (double)displayValue);
                                            storedValue = displayValue;
                                            lastOperation = Operation.POWER;
                                            break;
                                    }
                                    break;
                                case Operation.EQUALS:
                                    switch(lastOperation)
                                    {
                                        case Operation.PLUS:
                                            lastResult += storedValue;  
                                            lastOperation = Operation.PLUS;                        
                                            break;
                                        case Operation.MINUS:
                                            lastResult -= storedValue;  
                                            lastOperation = Operation.MINUS;                        
                                            break;
                                        case Operation.TIMES:
                                            lastResult *= storedValue;  
                                            lastOperation = Operation.TIMES;
                                            break;
                                        case Operation.DIVIDE:
                                            lastResult /= storedValue;  
                                            lastOperation = Operation.DIVIDE;                  
                                            break;
                                        case Operation.POWER:
                                            lastResult = (decimal)Math.Pow((double)lastResult, (double)storedValue);  
                                            lastOperation = Operation.POWER;                        
                                            break;
                                    }
                                    break;
                                default:
                                    update = false;
                                    break;
                            }
                        }
                        catch { error = true; }
                        if(update && !error)
                        {
                            displayValue = lastResult;
                            if(Math.Abs(displayValue) < 0.00000000001m) 
                            {   
                                displayValue = 0;
                                decimalPoint = 0;
                                lastOperation = Operation.EQUALS;
                                currentOperation = Operation.EQUALS;
                            }
                            if(displayValue%1 != 0)
                            {                            
                                decimalPoint = GetDecimalPoint(displayValue) + 1;
                                if(decimalPoint > 12)
                                {
                                    displayValue = Math.Round(displayValue, 12);
                                    decimalPoint = 12;
                                }
                            //Console.WriteLine(GetDecimalPoint(displayValue));
                            //Console.WriteLine(displayValue);
                            }
                            else
                            {
                                decimalPoint = 0;
                            }
                            digits.Clear();
                            currentOperation = Operation.EQUALS;
                        }
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine(decimalPoint);
            if(decimalPoint == 0) isDecimal = false;
            else isDecimal = true;
            //displayValue = decimal.Parse(displayValue.ToString("G29"));
            //Console.WriteLine("0." + new String('0', decimalPoint) + new String('#', (11-decimalPoint)));
            if(error) writableComponents[ComponentID.FIELD_0].Write("error", fontPath);
            else
            {
                if(decimalPoint>1) 
                {
                    if(Math.Abs(displayValue) > (decimal)Math.Pow(10, 10-decimalPoint))
                        writableComponents[ComponentID.FIELD_0].Write(displayValue.ToString("G8"), fontPath);
                    else
                        writableComponents[ComponentID.FIELD_0].Write(displayValue.ToString("F" + (decimalPoint-1).ToString()), fontPath);
                }
                else writableComponents[ComponentID.FIELD_0].Write(displayValue.ToString("G8"), fontPath);
            }
        }
        protected decimal displayValue = 0;
        protected decimal storedValue;
        protected decimal lastResult;
        protected bool isDecimal = false;
        protected bool error = false;
        protected int decimalPoint = 0;
        protected Operation currentOperation = Operation.EQUALS;
        protected Operation lastOperation = Operation.EQUALS;
        protected Stack<int> digits = new Stack<int>();
        protected int GetDecimalPoint(decimal value)
        {
            return value.ToString().Split('.')[1].Length;
        }
        protected void OperationHelper(Operation id)
        {
            if(!error)
            {
                if(currentOperation == Operation.ADD_NUMBER || currentOperation == Operation.EQUALS)
                {
                    storedValue = displayValue;
                    displayValue = 0;
                    decimalPoint = 0;
                    digits.Clear();
                    currentOperation = id;                        
                }
                lastOperation = id;
            }
        }
        protected void DigitHelper(int id)
        {
            if(!error)
            {
                if(isDecimal)
                {
                    displayValue += id/(decimal)(Math.Pow(10, decimalPoint));
                    decimalPoint ++;
                }
                else
                {

                    try
                    {
                        displayValue += id;
                    }
                    catch {error = true;}
                }
                digits.Push(id);
                currentOperation = Operation.ADD_NUMBER;
            }
        }
        public event EventHandler<MouseClickedEventArgs>? MouseClicked;
        protected virtual void OnMouseClicked(MouseClickedEventArgs e) => MouseClicked?.Invoke(this, e);
        public event EventHandler<KeyPressedEventArgs>? KeyPressed; //TODO Segregate events and invokes (readibility)
        protected virtual void OnKeyPressed(KeyPressedEventArgs e) => KeyPressed?.Invoke(this, e);
        public event EventHandler<RenderEventArgs>? Render;
        protected virtual void OnRender(RenderEventArgs e) => Render?.Invoke(this, e);
        protected void HandleEvents()
        {
            SDL.SDL_PollEvent(out lastEvent);
            switch(lastEvent.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    Quit();
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                    switch(lastEvent.button.button)
                    {
                        case (byte)SDL.SDL_BUTTON_LEFT:
                            
                            OnMouseClicked(new MouseClickedEventArgs(new Point(lastEvent.button.x, lastEvent.button.y)));
                            break;
                    }
                    break;
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    OnKeyPressed(new KeyPressedEventArgs(lastEvent.key.keysym.sym));
                    break;
                default:
                    break;
            }
        }
        protected void Update()
        {
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
            OnRender(new RenderEventArgs(renderer));
            //writableComponents[ComponentID.FIELD_0].Write("0123456789012", "fonts/VeraMono.ttf");
            SDL.SDL_RenderPresent(renderer);
            //Console.WriteLine("Updated!");
        }
        protected void Quit()
        {
            isAlive = false;
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_DestroyRenderer(renderer);
            //todo destroy textures here!!
            SDL.SDL_Quit();
        }
        protected IntPtr LoadTexture(string texturePath)
        {
            IntPtr tempsurf = SDL_image.IMG_Load(texturePath);
            IntPtr texture = SDL.SDL_CreateTextureFromSurface(renderer, tempsurf);
            SDL.SDL_FreeSurface(tempsurf);
            return texture;

        }
        protected SDL.SDL_Event lastEvent;
        protected IntPtr window;
        protected IntPtr renderer;
        protected bool isAlive = false;
        protected Dictionary<ComponentID, Component> components = new Dictionary<ComponentID, Component>();
        protected Dictionary<ComponentID, IWritable> writableComponents = new Dictionary<ComponentID, IWritable>();
    }
}