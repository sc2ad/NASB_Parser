﻿using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class StateAction : ISerializable
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public StateAction()
        {
        }

        protected StateAction(BulkSerializeReader reader)
        {
            // Reads past two ints
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static StateAction Read(BulkSerializeReader reader)
        {
            return (TypeId)reader.PeekInt() switch
            {
                TypeId.DebugId => new SADebugMessage(reader),
                TypeId.PlayAnimId => new SAPlayAnim(reader),
                TypeId.RootAnimId => new SAPlayRootAnim(reader),
                TypeId.SnapAnimWeightsId => new SASnapAnimWeights(reader),
                TypeId.StandardInputId => new SAStandardInput(reader),
                TypeId.InputId => new SAInputAction(reader),
                TypeId.DeactInputId => new SADeactivateInputAction(reader),
                TypeId.InputEventFromFrameId => new SAAddInputEventFromFrame(reader),
                TypeId.CancelStateId => new SACancelToState(reader),
                TypeId.CustomCallId => new SACustomCall(reader),
                TypeId.TimerId => new SATimedAction(reader),
                TypeId.OrderId => new SAOrderedSensitive(reader),
                TypeId.ProxyId => new SAProxyMove(reader),
                TypeId.CheckId => new SACheckThing(reader),
                TypeId.ActiveActionId => new SAActiveAction(reader),
                TypeId.DeactivateActionId => new SADeactivateAction(reader),
                TypeId.SetFloatId => new SASetFloatTarget(reader),
                TypeId.OnBounceId => new SAOnBounce(reader),
                TypeId.OnLeaveEdgeId => new SAOnLeaveEdge(reader),
                TypeId.OnStoppedAtEdgeId => new SAOnStoppedAtLedge(reader),
                TypeId.OnLandId => new SAOnLand(reader),
                TypeId.OnCancelId => new SAOnCancel(reader),
                TypeId.RefreshAtkId => new SARefreshAttack(reader),
                TypeId.EndAtkId => new SAEndAttack(reader),
                TypeId.SetHitboxCountId => new SASetHitboxCount(reader),
                TypeId.ConfigHitboxId => new SAConfigHitbox(reader),
                TypeId.SetAtkPropId => new SASetAttackProp(reader),
                TypeId.ManipHitboxId => new SAManipHitbox(reader),
                TypeId.UpdateHurtsetId => new SAUpdateHurtboxes(reader),
                TypeId.SetupHurtsetId => new SASetupHurtboxes(reader),
                TypeId.ManipHurtboxId => new SAManipHurtbox(reader),
                TypeId.BoneStateId => new SABoneState(reader),
                TypeId.BoneScaleId => new SABoneScale(reader),
                TypeId.SpawnAgentId => new SASpawnAgent(reader),
                TypeId.LocalFXId => new SALocalFX(reader),
                TypeId.SpawnFXId => new SASpawnFX(reader),
                TypeId.HitboxFXId => new SASetHitboxFX(reader),
                TypeId.SFXId => new SAPlaySFX(reader),
                TypeId.HitboxSFXId => new SASetHitboxSFX(reader),
                TypeId.ColorTintId => new SAColorTint(reader),
                TypeId.FindFloorId => new SAFindFloor(reader),
                TypeId.HurtGrabbedId => new SAHurtGrabbed(reader),
                TypeId.LaunchGrabbedId => new SALaunchGrabbed(reader),
                TypeId.StateCancelGrabbedId => new SAStateCancelGrabbed(reader),
                TypeId.EndGrabId => new SAEndGrab(reader),
                TypeId.GrabNotifyEscapeId => new SAGrabNotifyEscape(reader),
                TypeId.IgnoreGrabbedId => new SAIgnoreGrabbed(reader),
                TypeId.EventKOId => new SAEventKO(reader),
                TypeId.EventKOGrabbedId => new SAEventKOGrabbed(reader),
                TypeId.CameraShakeId => new SACameraShake(reader),
                TypeId.ResetOnHitId => new SAResetOnHits(reader),
                TypeId.OnHitId => new SAOnHit(reader),
                TypeId.FastForwardId => new SAFastForwardState(reader),
                TypeId.TimingTweakId => new SATimingTweak(reader),
                TypeId.MapAnimId => new SAMapAnimation(reader),
                TypeId.AlterMoveDtId => new SAAlterMoveDT(reader),
                TypeId.AlterMoveVelId => new SAAlterMoveVel(reader),
                TypeId.SetStagePartId => new SASetStagePart(reader),
                TypeId.SetStagePartsDefaultId => new SASetStagePartsDefault(reader),
                TypeId.JumpId => new SAJump(reader),
                TypeId.StopJumpId => new SAStopJump(reader),
                TypeId.ManageAirJumpId => new SAManageAirJump(reader),
                TypeId.LeaveGroundId => new SALeaveGround(reader),
                TypeId.UnhogEdgeId => new SAUnHogEdge(reader),
                TypeId.SFXTimelineId => new SAPlaySFXTimeline(reader),
                TypeId.FindLastHorizontalInputId => new SAFindLastHorizontalInput(reader),
                TypeId.SetCommandGrab => new SASetCommandGrab(reader),
                TypeId.CameraPunchId => new SACameraPunch(reader),
                TypeId.SpawnAgent2Id => new SASpawnAgent2(reader),
                TypeId.ManipDecorChainId => new SAManipDecorChain(reader),
                TypeId.UpdateHitboxesId => new SAUpdateHitboxes(reader),
                TypeId.SampleAnimId => new SASampleAnim(reader),
                TypeId.ForceExtraInputId => new SAForceExtraInputCheck(reader),
                TypeId.LaunchGrabbedCustomId => new SALaunchGrabbedCustom(reader),
                TypeId.MapAnimSimpleId => new SAMapAnimationSimple(reader),
                TypeId.PersistLocalFXId => new SAPersistLocalFX(reader),
                TypeId.OnLeaveParentId => new SAOnLeaveParent(reader),
                TypeId.BaseIdentifier => new StateAction(reader),
                _ => throw new ReadException(reader, $"Could not parse valid {nameof(StateAction)} type from: {reader.PeekInt()}!"),
            };
        }

        public enum TypeId
        {
            BaseIdentifier,
            DebugId,
            PlayAnimId,
            RootAnimId,
            SnapAnimWeightsId,
            StandardInputId,
            InputId,
            DeactInputId,
            InputEventFromFrameId,
            CancelStateId,
            CustomCallId,
            TimerId,
            OrderId,
            ProxyId,
            CheckId,
            ActiveActionId,
            DeactivateActionId,
            SetFloatId,
            OnBounceId,
            OnLeaveEdgeId,
            OnStoppedAtEdgeId,
            OnLandId,
            OnCancelId,
            RefreshAtkId,
            EndAtkId,
            SetHitboxCountId,
            ConfigHitboxId,
            SetAtkPropId,
            ManipHitboxId,
            UpdateHurtsetId,
            SetupHurtsetId,
            ManipHurtboxId,
            BoneStateId,
            BoneScaleId,
            SpawnAgentId,
            LocalFXId,
            SpawnFXId,
            HitboxFXId,
            SFXId,
            HitboxSFXId,
            ColorTintId,
            FindFloorId,
            HurtGrabbedId,
            LaunchGrabbedId,
            StateCancelGrabbedId,
            EndGrabId,
            GrabNotifyEscapeId,
            IgnoreGrabbedId,
            EventKOId,
            EventKOGrabbedId,
            CameraShakeId,
            ResetOnHitId,
            OnHitId,
            FastForwardId,
            TimingTweakId,
            MapAnimId,
            AlterMoveDtId,
            AlterMoveVelId,
            SetStagePartId,
            SetStagePartsDefaultId,
            JumpId,
            StopJumpId,
            ManageAirJumpId,
            LeaveGroundId,
            UnhogEdgeId,
            SFXTimelineId,
            FindLastHorizontalInputId,
            SetCommandGrab,
            CameraPunchId,
            SpawnAgent2Id,
            ManipDecorChainId,
            UpdateHitboxesId,
            SampleAnimId,
            ForceExtraInputId,
            LaunchGrabbedCustomId,
            MapAnimSimpleId,
            PersistLocalFXId,
            OnLeaveParentId
        }
    }
}