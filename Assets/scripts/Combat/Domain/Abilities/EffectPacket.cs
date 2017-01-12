using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EffectPacket
{
    public int dmg;
    public int stunFrames;
	public Condition cond;

    public EffectPacket()
    {
        this.dmg = 0;
        this.stunFrames = 0;
    }

    public EffectPacket(int dmg, int stunFrames)
    {
        this.dmg = dmg;
        this.stunFrames = stunFrames;
    }

	public EffectPacket(int dmg, int stunFrames, Condition cond){
		this.dmg = dmg;
		this.stunFrames = stunFrames;
		this.cond = cond;
	}

	public EffectPacket(Condition cond){
		this.dmg = 0;
		this.stunFrames = 0;
		this.cond = cond;
	}
}
