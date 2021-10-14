using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class StateAction
    {
        public StateAction()
        {
        }

        internal StateAction(BulkSerializer reader)
        {
            // Reads past two ints
            _ = reader.ReadInt();
            _ = reader.ReadInt();
        }

        public static StateAction Read(BulkSerializer reader)
        {
            switch ((TypeId)reader.PeekInt())
            {
                case TypeId.DebugId:
                    return new SADebugMessage(reader);

                case TypeId.PlayAnimId:
                    return new SAPlayAnim(reader);

                case TypeId.RootAnimId:
                    return new SAPlayRootAnim(reader);

                case TypeId.SnapAnimWeightsId:
                    break;

                case TypeId.StandardInputId:
                    break;

                case TypeId.InputId:
                    break;

                case TypeId.DeactInputId:
                    break;

                case TypeId.InputEventFromFrameId:
                    break;

                case TypeId.CancelStateId:
                    break;

                case TypeId.CustomCallId:
                    break;

                case TypeId.TimerId:
                    break;

                case TypeId.OrderId:
                    break;

                case TypeId.ProxyId:
                    break;

                case TypeId.CheckId:
                    break;

                case TypeId.ActiveActionId:
                    break;

                case TypeId.DeactivateActionId:
                    break;

                case TypeId.SetFloatId:
                    break;

                case TypeId.OnBounceId:
                    break;

                case TypeId.OnLeaveEdgeId:
                    break;

                case TypeId.OnStoppedAtEdgeId:
                    break;

                case TypeId.OnLandId:
                    break;

                case TypeId.OnCancelId:
                    break;

                case TypeId.RefreshAtkId:
                    break;

                case TypeId.EndAtkId:
                    break;

                case TypeId.SetHitboxCountId:
                    break;

                case TypeId.ConfigHitboxId:
                    break;

                case TypeId.SetAtkPropId:
                    break;

                case TypeId.ManipHitboxId:
                    break;

                case TypeId.UpdateHurtsetId:
                    break;

                case TypeId.SetupHurtsetId:
                    break;

                case TypeId.ManipHurtboxId:
                    break;

                case TypeId.BoneStateId:
                    break;

                case TypeId.BoneScaleId:
                    break;

                case TypeId.SpawnAgentId:
                    break;

                case TypeId.LocalFXId:
                    break;

                case TypeId.SpawnFXId:
                    break;

                case TypeId.HitboxFXId:
                    break;

                case TypeId.SFXId:
                    break;

                case TypeId.HitboxSFXId:
                    break;

                case TypeId.ColorTintId:
                    break;

                case TypeId.FindFloorId:
                    break;

                case TypeId.HurtGrabbedId:
                    break;

                case TypeId.LaunchGrabbedId:
                    break;

                case TypeId.StateCancelGrabbedId:
                    break;

                case TypeId.EndGrabId:
                    break;

                case TypeId.GrabNotifyEscapeId:
                    break;

                case TypeId.IgnoreGrabbedId:
                    break;

                case TypeId.EventKOId:
                    break;

                case TypeId.EventKOGrabbedId:
                    break;

                case TypeId.CameraShakeId:
                    break;

                case TypeId.ResetOnHitId:
                    break;

                case TypeId.OnHitId:
                    break;

                case TypeId.FastForwardId:
                    break;

                case TypeId.TimingTweakId:
                    break;

                case TypeId.MapAnimId:
                    break;

                case TypeId.AlterMoveDtId:
                    break;

                case TypeId.AlterMoveVelId:
                    break;

                case TypeId.SetStagePartId:
                    break;

                case TypeId.SetStagePartsDefaultId:
                    break;

                case TypeId.JumpId:
                    break;

                case TypeId.StopJumpId:
                    break;

                case TypeId.ManageAirJumpId:
                    break;

                case TypeId.LeaveGroundId:
                    break;

                case TypeId.UnhogEdgeId:
                    break;

                case TypeId.SFXTimelineId:
                    break;

                case TypeId.FindLastHorizontalInputId:
                    break;

                case TypeId.SetCommandGrab:
                    break;

                case TypeId.CameraPunchId:
                    break;

                case TypeId.SpawnAgent2Id:
                    break;

                case TypeId.ManipDecorChainId:
                    break;

                case TypeId.UpdateHitboxesId:
                    break;

                case TypeId.SampleAnimId:
                    break;

                case TypeId.ForceExtraInputId:
                    break;

                case TypeId.LaunchGrabbedCustomId:
                    break;

                case TypeId.BaseIdentifier:
                default:
                    return new StateAction(reader);
            }
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
            LaunchGrabbedCustomId
        }
    }
}