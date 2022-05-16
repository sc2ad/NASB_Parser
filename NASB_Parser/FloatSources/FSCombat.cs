using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSCombat : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCombat()
        {
        }

        internal FSCombat(BulkSerializeReader reader) : base(reader)
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
            Weight,
            Getgrabbed,
            Grabinvulnerability,
            BlockPush,
            BlockHoldVertical = 8,
            BlockHoldHorizontal,
            CheckBlastzones = 14,
            CheckTopBlastzone,
            AlwaysLaunch = 24,
            PreventHitstunTurn = 28,
            PreventLaunches,
            DamageTaken = 4,
            InvincibleBoonFrames,
            RespawnInvincibleFrames,
            IsProjectile = 25,
            Projectilelevel = 7,
            LastDIType = 10,
            LastDIIn,
            LastDIOut,
            LastBlastzone,
            LastTurn = 16,
            LastRedirectX,
            LastRedirectY,
            LaunchedByPlayerIndex,
            LaunchedByTeam,
            LaunchedByGameTeam = 26,
            LastHitType = 21,
            LastHitDirection,
            LastHitForceJabReset = 27,
            LastHitForward = 23,
            ChainCount = 30,
            ComboCount = 31,
            AltLaunch = 32,
            DirectionX = 33,
            DirectionY = 34,
            DistanceTotal = 35,
            DistanceX = 36,
            DistanceY = 37,
            TravelTotal = 38,
            TravelX = 39,
            TravelY = 40,
            TravelAbsoluteTotal = 41,
            TravelAbsoluteX = 42,
            TravelAbsoluteY = 43,
            LaunchRate = 44,
            LaunchVelocityX = 45,
            LaunchVelocityY = 46,
            LaunchVelocityTrueX = 47,
            LaunchVelocityTrueY = 48,
            TravelAngle = 49
        }
    }
}