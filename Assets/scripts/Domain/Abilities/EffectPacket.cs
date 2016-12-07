using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EffectPacket
{
    public int dmg;
    public int heal;
    public int stunFrames;

    public EffectPacket()
    {
        this.dmg = 0;
        this.heal = 0;
        this.stunFrames = 0;
    }

    public EffectPacket(int dmg, int heal, int stunFrames)
    {
        this.dmg = dmg;
        this.heal = heal;
        this.stunFrames = stunFrames;
    }
}
