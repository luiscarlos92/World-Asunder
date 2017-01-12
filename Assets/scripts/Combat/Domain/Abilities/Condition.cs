using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Condition
{
	public int dmg;
	public int stunFrames;
	public int totalFrames;
	public int frameStep;
	public int immortalFrames;

	public Condition()
	{
		this.dmg = 0;
		this.stunFrames = 0;
		this.totalFrames = 0;
		this.frameStep = 0;
	}

	//DOT, HOT
	public Condition(int dmg, int totalFrames, int frameStep)
	{
		this.dmg = dmg;
		this.stunFrames = 0;
		this.totalFrames = totalFrames;
		this.frameStep = frameStep;
	}

	//invis
	public Condition(int immuneFrames)
	{
		this.dmg = 0;
		this.stunFrames = 0;
		this.totalFrames = immuneFrames;
		this.frameStep = 0;
		this.immortalFrames = immuneFrames;
	}


}


