namespace NASB_Parser.StateActions
{
	public class SAOnLeaveParent : StateAction
	{
		public StateAction Action { get; set; }

		public SAOnLeaveParent() 
		{ }

		internal SAOnLeaveParent(BulkSerializeReader reader) : base(reader)
		{
			Action = Read(reader);
		}

		public override void Write(BulkSerializeWriter writer)
		{
			base.Write(writer);
			writer.Write(Action);
		}
	}
}