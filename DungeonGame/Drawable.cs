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
        private const int WH = 30;
        public int posx, posy;
        public View.MainWindow form;
        public fieldtype type;
        public Rectangle rect;
        public Field(int x, int y, View.MainWindow form, fieldtype type)
        {
            this.posx = x;
            this.posy = y;
            this.form = form;
            this.type = type;
            rect = new Rectangle(this.posx * (WH - 1), this.posy * (WH - 1), WH, WH);
        }
        public void draw()
        {
            Graphics g = this.form.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            refresh();        
            g.DrawRectangle(p, rect);
            g.Dispose();
            p.Dispose();
            
        }
        public void refresh()
        {
            Graphics g = this.form.CreateGraphics();
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
        
    }
}
