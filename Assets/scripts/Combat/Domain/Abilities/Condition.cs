using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Condition
{
	public int dmg = 0;
	public int stunFrames = 0 ;
	public int totalFrames= 0 ;
    public int doneFrame;
	public int frameStep = 1;
    public int frameStepCounter = 0;
	public int immortalFrames = 0;

	public Condition()
	{
		this.dmg = 0;
		this.stunFrames = 0;
		this.totalFrames = 0;
        this.doneFrame = 0;
		this.frameStep = 0;
        
	}

	//DOT, HOT
	public Condition(int dmg, int totalFrames, int frameStep)
	{
		this.dmg = dmg;
		this.stunFrames = 0;
		this.totalFrames = totalFrames;
        this.doneFrame = totalFrames;
		this.frameStep = frameStep;
        this.frameStepCounter = frameStep;
	}

	//invis
	public Condition(int immuneFrames)
	{
		this.dmg = 0;
		this.stunFrames = 0;
		this.totalFrames = immuneFrames;
		this.frameStep = 1;
		this.immortalFrames = immuneFrames;
	}


}


