using System.Security.Principal;

namespace DataBase.Interface
{
    public class BodyList : View //класс списка страниц
    {
        List<Body> bodies;
        int ActiveBody;
        
        public BodyList(int x, int y, int height, int width):base(x, y, height, width)
        {
            bodies = new List<Body>();
            bodies.Add(new AuthBody( x, y, height, width )); // добавление боди
            ActiveBody = 0;
        }
        

        virtual public void KeyDetect(ConsoleKeyInfo keyInfo)
        {
            int PreviuosBodyCount = bodies.Count;
            bodies = bodies[ActiveBody].KeyDetect(keyInfo, bodies);

            if (PreviuosBodyCount != bodies.Count) 
            {
                ActiveBody = bodies.Count - 1;
            }
            
        }
        
        public override void Draw()
        {
            Console.Clear();
            
            foreach (var s in bodies)
            {
                s.Draw();
            }

            if (bodies.Count > 0)
            {
                bodies[ActiveBody].Draw();
            }
        }
    }
}

