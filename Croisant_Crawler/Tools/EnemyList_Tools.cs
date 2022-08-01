

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Croisant_Crawler.Core.Tools;

[Obsolete]
public static class EnemyList_Tools
{
	public static void CreateExampleFile()
	{
		List<Stats_Prototype> list = new();
		list.Add(new Stats_Prototype());
		list.Add(new Stats_Prototype());

		File.WriteAllText("Res/enemies_example.json", JsonSerializer.Serialize<List<Stats_Prototype>>(list));
	}
}