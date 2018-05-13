using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawEnvironment
{
    interface Drawable
    {
        void draw();

    }


    public enum fieldtype
    {
        EMPTY, WALL, ENTRANCE, EXIT, INDESTRUCTABLE
    }


    public class Field : Drawable
    {
        private static int WH = 30; //width height
        public int posx, posy;
        public System.Windows.Forms.Panel canvas;
        public fieldtype type;
        public Rectangle rect;
        public Field(int x, int y, System.Windows.Forms.Panel canvas, fieldtype type)
        {
            this.posx = x;
            this.posy = y;
            this.canvas = canvas;
            this.type = type;
            rect = new Rectangle(this.posx * (WH - 1), this.posy * (WH - 1), WH, WH);
        }
        public void draw()
        {
            rect = new Rectangle(this.posx * (WH - 1), this.posy * (WH - 1), WH, WH);
            Graphics g = this.canvas.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            refresh();        
            g.DrawRectangle(p, rect);
            g.Dispose();
            p.Dispose();
            
        }
        public void refresh() // Kanten werden sonst übermalt
        {
            Graphics g = this.canvas.CreateGraphics();
            SolidBrush brush;
           
            if (this.type == fieldtype.EMPTY)
            {
                brush = new SolidBrush(Color.AntiqueWhite);

            }
            else if (this.type == fieldtype.WALL)
            {
                brush = new SolidBrush(Color.Black);
            }
            else if (this.type == fieldtype.ENTRANCE)
            {
                brush = new SolidBrush(Color.BlueViolet);
            }
            else if(this.type == fieldtype.INDESTRUCTABLE)
            {
                brush = new SolidBrush(Color.DarkSlateGray);
            }
            else //Exit
            {
                brush = new SolidBrush(Color.Yellow);
            }

            g.FillRectangle(brush, rect);
            g.Dispose();
            brush.Dispose();
        }
        
        public static void adaptSize(int boardWidth, int boardHeight, System.Windows.Forms.Panel canvas)
        {
            WH = Math.Min(canvas.Width / boardWidth, canvas.Height / boardHeight);
        }
    }
}
