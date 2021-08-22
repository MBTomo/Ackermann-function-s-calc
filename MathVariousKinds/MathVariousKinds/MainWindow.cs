using System;
using Gtk;
using MathVariousKinds;

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

    long num1 = 0; long num2 = 0; long count = 0; long num3 = 0; long i = 0;
    long[] Ack = new long[0];
    bool numcheck = true;
    bool one = false;
    bool man = false;
    bool oku = false;

    protected void Button1_Clicked(object sender, EventArgs e)
    {
        var sw = new System.Diagnostics.Stopwatch();
        label5.Text = "計測中";
        entry4.Text = "";
        Button2.Label = "計算中";
        count = 0;
        ComboChanged();
        ComboKawaru();
        sw.Start();
        numcheck = true;
        if (long.TryParse(entry1.Text,out i)==false || long.TryParse(entry2.Text, out i) == false || long.TryParse(entry3.Text, out i) == false)
        {
            MessageDialog msg = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "自然数を入力してください");
            msg.Run();
            msg.Destroy();
            numcheck = false;
        }
        for(int j=0; j<1; j++)
        {
            if (numcheck == false) break;
            if (one == true) num3 = long.Parse(entry3.Text);
            else if (man == true) num3 = (long.Parse(entry3.Text) * 10000);
            else if (oku == true) num3 = (long.Parse(entry3.Text) * 10000 * 10000);
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
                count++;
                if (num3 == 0) { }
                else if (count % num3 == 0)
                {
                    sw.Stop();
                    TimeSpan ts1 = sw.Elapsed;
                    Button2.Label = "計算";
                    label5.Text = $"{ts1.Hours}時間 {ts1.Minutes}分 {ts1.Seconds}秒 {ts1.Milliseconds}";
                    MessageDialog msg2 = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, count + "回の計算が終了しました。");
                    msg2.Run();
                    msg2.Destroy();
                    sw.Start();
                }
            }
            num2 = Ack[Ack.Length - 1] + 1;
            entry4.Text = num2.ToString();
            count++;
            sw.Stop();
            MessageDialog msg3 = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, count + "回の計算が終了したところで、計算結果が出ました。");
            msg3.Run();
            msg3.Destroy();

        }
        if (numcheck == false)
        {
            //entry1.Text = "";
            //entry2.Text = "";
            entry4.Text = "NaN";
        }
        TimeSpan ts = sw.Elapsed;
        Button2.Label = "計算";
        label5.Text = $"{ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}";
    }

    protected void OnAction1Activated(object sender, EventArgs e)
    {
        Application.Quit();
    }
    protected void ComboKawaru()
    {
        if (comboboxentry1.ActiveText == "一") one = true;
        else if (comboboxentry1.ActiveText == "万") man = true;
        else if (comboboxentry1.ActiveText == "億") oku = true;

    }
    protected void ComboChanged()
    {
        one = false;
        man = false;
        oku = false;
    }

    protected void OnAction4Activated(object sender, EventArgs e)
    {
        BenchMarkWindow win2 = new BenchMarkWindow();
        win2.Show();
    }
}
