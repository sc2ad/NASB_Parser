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

        internal FSCombat(BulkSerializer reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
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
            LastHitForward = 23
        }
    }
}