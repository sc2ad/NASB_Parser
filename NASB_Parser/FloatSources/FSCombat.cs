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
            LaunchLastFrameX = 50,
            LaunchLastFrameY = 51,
            TravelAngle = 49,
            LastAttackType = 52,
            LastAttackDamageBase = 53,
            LastAttackDamageMult = 54,
            LastAttackKnockbackMult = 55,
            LastAttackDamageTotal = 56,
            LastAttackAngle = 57,
            LastAttackDirection = 58,
            LastAttackDiType = 59,
            LastAttackDiIn = 60,
            LastAttackDiOut = 61,
            LastAttackReversible = 62,
            LastAttackKnockbackType = 63,
            LastAttackKnockbackBase = 64,
            LastAttackKnockbackGain = 65,
            LastAttackExtraKbAboveKb = 66,
            LastAttackExtraKbMult = 67,
            LastAttackStunCalc = 68,
            LastAttackStunBase = 69,
            LastAttackStunGain = 70,
            LastAttackHitOpponent = 71,
            LastAttackInteractDirection = 72,
            LastAttackBlockstun = 73,
            LastAttackBlockpush = 74,
            LastAttackBlocklag = 75,
            LastAttackHitlag = 76,
            LastAttackHitlagSelf = 77,
            LastAttackLauncher = 78,
            LastAttackLaunchAboveKb = 79,
            LastAttackLaunchArmorLevel = 80,
            LastAttackForceJabReset = 81,
            LastAttackGrablevel = 82,
            LastAttackGrabtype = 83,
            LastAttackKillshot = 84,
            LastAttackDirectionalfx = 85,
            LastAttackUnblockable = 86,
            LastAttackPierceinvincible = 87,
            LastAttackUninterruptible = 88,
            LastAttackAerial = 89
        }
    }
}