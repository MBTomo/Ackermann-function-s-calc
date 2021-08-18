using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    long num1 = 0; long num2 = 0; long i = 0;
    long[] Ack = new long[0];
    bool numcheck = true;


    protected void Button1_Clicked(object sender, EventArgs e)
    {
        var sw = new System.Diagnostics.Stopwatch();
        label5.Text = "計測中";
        entry4.Text = "";
        Button2.Label = "計算中";
        sw.Start();
        numcheck = true;
        if (long.TryParse(entry1.Text,out i)==false || long.TryParse(entry2.Text, out i) == false)
        {
            MessageDialog msg = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "自然数を入力してください");
            msg.Run();
            msg.Destroy();
            numcheck = false;
        }
        for(int j=0; j<1; j++)
        {
            if (numcheck == false) break;
            Ack = new long[2] { long.Parse(entry1.Text), long.Parse(entry2.Text) };
            while (Ack.Length != 2 || Ack[0] != 0)
            {
                num1 = 0; num2 = 0;
                if (Ack[Ack.Length - 1] == 0)
                {
                    Ack[Ack.Length - 2]--;
                    Ack[Ack.Length - 1] = 1;
                }
                else if (Ack[Ack.Length - 2] == 0)
                {
                    num1 = Ack[Ack.Length - 1];
                    Array.Resize(ref Ack, Ack.Length - 1);
                    Ack[Ack.Length - 1] = num1 + 1;
                }
                else
                {
                    num1 = Ack[Ack.Length - 1];
                    num2 = Ack[Ack.Length - 2];
                    Array.Resize(ref Ack, Ack.Length + 1);
                    Ack[Ack.Length - 3] = num2 - 1;
                    Ack[Ack.Length - 2] = num2;
                    Ack[Ack.Length - 1] = num1 - 1;
                }
            }
            num2 = Ack[Ack.Length - 1] + 1;
            entry4.Text = num2.ToString();
        }
        if (numcheck == false)
        {
            entry1.Text = "";
            entry2.Text = "";
            entry4.Text = "NaN";
        }
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        Button2.Label = "計算";
        label5.Text = $"{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}";
    }

    protected void OnAction1Activated(object sender, EventArgs e)
    {
        Application.Quit();
    }
}
