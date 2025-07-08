using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmPerplexityWeb;

public partial class HmPerplexityWeb
{
    private const byte VK_ESC = 0x1B; // ESCキーの仮想キーコード

    public void SendCtrlJKeySync()
    {
        SendCtrlJKey();
    }

    private async void SendCtrlJKey()
    {
        // Ctrl キーを解放
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        // Alt キーを解放
        keybd_event(VK_ALT, 0, KEYEVENTF_KEYUP, 0);

        // shiftキーを解放
        keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);


        await Task.Delay(100);

        // CTRLキーを押す
        keybd_event(VK_CONTROL, 0, 0, 0);

        // Jキーを押す
        keybd_event((byte)'J', 0, 0, 0);

        await Task.Delay(200);

        // Jキーを離す
        keybd_event((byte)'J', 0, KEYEVENTF_KEYUP, 0);
        // CTRLキーを離す
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);

    }


}
