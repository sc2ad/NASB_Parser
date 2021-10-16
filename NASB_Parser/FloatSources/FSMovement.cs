using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSMovement : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSMovement()
        {
        }

        internal FSMovement(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }

        public enum Attributes
        {
            Vel_X,
            Vel_X_raw,
            Vel_Y,
            Direction,
            Grounded = 36,
            ClosestParentEdge = 60,
            Last_move_X_raw = 50,
            Last_move_Y,
            IncreaseMoveDT = 4,
            IncreaseMoveDTFalloff,
            AllowCtrl,
            RootPosReset,
            ForceNextFloorCheck,
            CheckFloorFromMid,
            ExtendFloorCheckToMid = 58,
            CheckFloorThickness = 53,
            FallSpeed = 10,
            FallSpeedMultiplier = 44,
            Gravity = 11,
            Antigravity = 65,
            FloorFriction = 12,
            FloorAcc,
            FloorDec = 61,
            FloorBrake = 14,
            FloorSpeed,
            FloorDecay = 64,
            AirFriction = 63,
            AirAcc = 16,
            AirDec = 62,
            AirBrake = 17,
            AirSpeed,
            AirDecay,
            XSpeedMultiplier = 45,
            RootMotionMult_X = 20,
            RootMotionMult_Y,
            ResizeCollision,
            MinColH,
            MinColW,
            ExtendBottom,
            BottomCollisionWorldPos = 57,
            CrowdPushing = 37,
            CrowdPushRadius,
            CrowdPushWeight = 48,
            CrowdPushMaxDistPerFrame = 52,
            CrowdPushingFromLedge = 66,
            GrabEdge = 39,
            GrabEdgeExtendFwd,
            GrabEdgeExtendBack,
            GrabEdgeExtendUp,
            GrabEdgeExtendDown,
            DisableMovement = 56,
            DisableCollision = 59,
            DisableSink = 67,
            GetParented = 26,
            LeaveEdges,
            FallThrough,
            PassThrough = 46,
            IgnoreMovingStage = 29,
            Bounce,
            Stop,
            LeaveParent,
            InheritParentVel,
            LeaveEdgeRestrict = 47,
            SimpleFreeMovement = 54,
            SimpleRadius,
            FloorTilt = 34,
            SolidGround,
            ParentOrderAdded = 49
        }
    }
}