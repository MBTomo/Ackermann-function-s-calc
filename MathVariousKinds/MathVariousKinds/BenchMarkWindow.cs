using System;
namespace MathVariousKinds
{
    public partial class BenchMarkWindow : Gtk.Window
    {
        public BenchMarkWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        long num1 = 0; long num2 = 0; int count1 = 0;
        long[] Ack1 = { 3, 8 };
        int II = 10;

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            var sw = new System.Diagnostics.Stopwatch();
            for(int i=0; i<II; i++)
            {
                Ack1 = new long[] { 3, 8 };
                sw.Start();
                while (Ack1.Length != 2 || Ack1[0] != 0)
                {
                    num1 = 0; num2 = 0;
                    if (Ack1[Ack1.Length - 1] == 0)
                    {
                        Ack1[Ack1.Length - 2]--;
                        Ack1[Ack1.Length - 1] = 1;
                    }
                    else if (Ack1[Ack1.Length - 2] == 0)
                    {
                        num1 = Ack1[Ack1.Length - 1];
                        Array.Resize(ref Ack1, Ack1.Length - 1);
                        Ack1[Ack1.Length - 1] = num1 + 1;
                    }
                    else
                    {
                        num1 = Ack1[Ack1.Length - 1];
                        num2 = Ack1[Ack1.Length - 2];
                        Array.Resize(ref Ack1, Ack1.Length + 1);
                        Ack1[Ack1.Length - 3] = num2 - 1;
                        Ack1[Ack1.Length - 2] = num2;
                        Ack1[Ack1.Length - 1] = num1 - 1;
                    }
                }
                num2 = Ack1[Ack1.Length - 1] + 1;
                sw.Stop();
                count1++;
                entry1.Text = "10回中" + count1 + "回目終了";
            }
            double num3 = 7730217800000/Math.Pow(((sw.ElapsedMilliseconds*10)/II), 2);
            entry1.Text = num3.ToString();
        }
    }
}
