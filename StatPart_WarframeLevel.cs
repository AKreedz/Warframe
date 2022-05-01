using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Warframe
{
    internal class StatPart_WarframeLevel : StatPart
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x00008A28 File Offset: 0x00006C28
		public override string ExplanationPart(StatRequest req)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Pawn wf = req.Thing as Pawn;
			bool flag = wf != null;
			if (flag)
			{
				Pawn_RecordsTracker pr = wf.records;
				if (pr != null)
				{
					float killh = pr.GetValue(RecordDefOf.KillsHumanlikes);
					float killm = pr.GetValue(RecordDefOf.KillsMechanoids);
					stringBuilder.AppendLine("Warframe_Explanation_HumansKillCount".Translate() + ": " + killh+"(+"+Math.Ceiling(killh*2f)+")");
					stringBuilder.AppendLine("Warframe_Explanation_MechaoidsKillCount".Translate() + ": " + killm + "(+" + Math.Ceiling(killm * 5f) + ")");
				 
				}
				
			}
			
			 
			return stringBuilder.ToString();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00008B54 File Offset: 0x00006D54
		public override void TransformValue(StatRequest req, ref float val)
		{
			Pawn wf = req.Thing as Pawn;
			bool flag = wf != null;
			val = 1;
			if (flag&&wf.isWarframe())
			{
				val = WarframeStaticMethods.getWFLevel(wf);
			}
			 
		}

		// Token: 0x040000E8 RID: 232
		private const float fuelToPowerFactor = 15f;
	}
}
