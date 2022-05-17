
using NASB_Parser.FloatSources;

namespace NASB_Parser.StateActions
{
	public class SAPersistLocalFX : StateAction
	{
		public string Id { get; set; }
		public FloatSource Persist { get; set; }
		public bool MaxOut { get; set; }

		public SAPersistLocalFX()
		{
		}

		public SAPersistLocalFX(BulkSerializeReader reader) : base(reader)
		{
			Id = reader.ReadString();
			Persist = FloatSource.Read(reader);
			MaxOut = reader.ReadBool();
		}

		public override void Write(BulkSerializeWriter writer)
		{
			base.Write(writer);
			writer.AddString(Id);
			if (Persist == null)
				Persist = new FSValue(-1f);
			writer.Write(Persist);
			writer.Write(MaxOut);
		}
	}
} 