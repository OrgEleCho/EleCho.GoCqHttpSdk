using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using EleCho.GoCqHttpSdk.JsonConverter;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Message.JsonConverter;
using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Post.JsonConverter;
using EleCho.GoCqHttpSdk.Post.Model;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.Unicode;

namespace EleCho.GoCqHttpSdk.Utils
{
    internal static class JsonHelper
    {
        private static Lazy<JsonSerializerOptions> options = new Lazy<JsonSerializerOptions>(NewOptions);

        private static JsonSerializerOptions NewOptions()
        {
            return new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                Converters =
                {
                    new CqWsDataModelConverter(),

                    new CqPostModelConverter(),
                    new CqMessageEventModelConverter(),
                    new CqSelfMessageEventModelConverter(),

                    new CqNoticeEventModelConverter(),
                    new CqNoticeNotifyEventModelConverter(),

                    new CqMetaEventModelConverter(),

                    new CqRequestEventModelConverter(),

                    new CqMsgModelArrayConverter(),
                    new CpMsgModelConverter(),
                }
            };
        }

        public static JsonSerializerOptions Options =>
#if DEBUG
            debugOptions.Value;
#else
            options.Value;
#endif

#if DEBUG
        private static Lazy<JsonSerializerOptions> debugOptions = new(NewDebugOptions);

        private static JsonSerializerOptions NewDebugOptions()
        {
            return new JsonSerializerOptions()
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                Converters =
                {
                    new CqWsDataModelConverter(),

                    new CqPostModelConverter(),
                    new CqMessageEventModelConverter(),
                    new CqSelfMessageEventModelConverter(),

                    new CqNoticeEventModelConverter(),
                    new CqNoticeNotifyEventModelConverter(),

                    new CqMetaEventModelConverter(),

                    new CqRequestEventModelConverter(),

                    new CqMsgModelArrayConverter(),
                    new CpMsgModelConverter(),
                },
#if NET7_0_OR_GREATER
                TypeInfoResolver = JsonGeneratorSourceContext.Default;
#endif
            };
        }

#endif
    }
}

#if NET7_0_OR_GREATER
[JsonSourceGenerationOptions]
[JsonSerializable(typeof(CqWsDataModel))]
[JsonSerializable(typeof(CqPostModel))]
[JsonSerializable(typeof(CqActionModel))]
[JsonSerializable(typeof(CqActionResultRaw))]

[JsonSerializable(typeof(CqMessagePostModel))]
[JsonSerializable(typeof(CqSelfMessagePostModel))]
[JsonSerializable(typeof(CqNoticePostModel))]
[JsonSerializable(typeof(CqRequestPostModel))]
[JsonSerializable(typeof(CqMetaPostModel))]

[JsonSerializable(typeof(CqPrivateMessagePostModel))]
[JsonSerializable(typeof(CqGroupMessagePostModel))]

[JsonSerializable(typeof(CqPrivateSelfMessagePostModel))]
[JsonSerializable(typeof(CqGroupSelfMessagePostModel))]

[JsonSerializable(typeof(CqNoticeGroupUploadPostModel))]
[JsonSerializable(typeof(CqNoticeGroupAdminPostModel))]
[JsonSerializable(typeof(CqNoticeGroupIncreasePostModel))]
[JsonSerializable(typeof(CqNoticeGroupDecreasePostModel))]
[JsonSerializable(typeof(CqNoticeGroupBanPostModel))]
[JsonSerializable(typeof(CqNoticeFriendAddPostModel))]
[JsonSerializable(typeof(CqNoticeGroupRecallPostModel))]
[JsonSerializable(typeof(CqNoticeFriendRecallPostModel))]
[JsonSerializable(typeof(CqNoticeGroupCardPostModel))]
[JsonSerializable(typeof(CqNoticeOfflineFilePostModel))]
[JsonSerializable(typeof(CqNoticeNotifyPostModel))]

[JsonSerializable(typeof(CqNoticePokePostModel))]
[JsonSerializable(typeof(CqNoticeLuckyKingPostModel))]
[JsonSerializable(typeof(CqNoticeHonorPostModel))]
[JsonSerializable(typeof(CqNoticeTitlePostModel))]

[JsonSerializable(typeof(CqMetaLifecyclePostModel))]
[JsonSerializable(typeof(CqMetaHeartbeatPostModel))]

[JsonSerializable(typeof(CqRequestFriendPostModel))]
[JsonSerializable(typeof(CqRequestGroupPostModel))]

[JsonSerializable(typeof(CqMsgModel))]
[JsonSerializable(typeof(CqMsgModel<CqAnonymousMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqAtMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqCardImageMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqContactMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqCustomMusicMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqDiceMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqFaceMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqForwardMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqGiftMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqImageMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqJsonMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqLocationMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqMusicMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqPokeMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqRecordMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqRedEnvelopeMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqReplyMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqRpsMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqShakeMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqShareMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqTextMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqTtsMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqVideoMsgDataModel>))]
[JsonSerializable(typeof(CqMsgModel<CqXmlMsgDataModel>))]

[JsonSerializable(typeof(CqActionParamsModel))]
[JsonSerializable(typeof(CqBanGroupAllMembersActionParamsModel))]
[JsonSerializable(typeof(CqBanGroupAnonymousMemberActionParamsModel))]
[JsonSerializable(typeof(CqBanGroupMemberActionParamsModel))]
[JsonSerializable(typeof(CqCanSendImageActionParamsModel))]
[JsonSerializable(typeof(CqCanSendRecordActionParamsModel))]
[JsonSerializable(typeof(CqCheckUrlSafetyActionParamsModel))]
[JsonSerializable(typeof(CqCreateGroupFolderActionParamsModel))]
[JsonSerializable(typeof(CqDeleteEssenceMessageActionParamsModel))]
[JsonSerializable(typeof(CqDeleteFriendActionParamsModel))]
[JsonSerializable(typeof(CqDeleteGroupFileActionParamsModel))]
[JsonSerializable(typeof(CqDeleteGroupFolderActionParamsModel))]
[JsonSerializable(typeof(CqDeleteUnidirectionalFriendActionParamsModel))]
[JsonSerializable(typeof(CqDownloadFileActionParamsModel))]
[JsonSerializable(typeof(CqGetCookiesActionParamsModel))]
[JsonSerializable(typeof(CqGetCsrfTokenActionParamsModel))]
[JsonSerializable(typeof(CqGetEssenceMessageListActionParamsModel))]
[JsonSerializable(typeof(CqGetForwardMessageActionParamsModel))]
[JsonSerializable(typeof(CqGetFriendListActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupFilesByFolderActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupFileSystemInformationActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupFileUrlActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupInformationActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupListActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupMemberInformationActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupMemberListActionParamsModel))]
[JsonSerializable(typeof(CqGetGroupRootFilesActionParamsModel))]
[JsonSerializable(typeof(CqGetImageActionParamsModel))]
[JsonSerializable(typeof(CqGetLoginInformationActionParamsModel))]
[JsonSerializable(typeof(CqGetMessageActionParamsModel))]
[JsonSerializable(typeof(CqGetModelShowActionParamsModel))]
[JsonSerializable(typeof(CqGetOnlineClientsActionParamsModel))]
[JsonSerializable(typeof(CqGetStrangerInformationActionParamsModel))]
[JsonSerializable(typeof(CqGetUnidirectionalFriendListActionParamsModel))]
[JsonSerializable(typeof(CqGetVersionInformationActionParamsModel))]
[JsonSerializable(typeof(CqGetWordSlicesActionParamsModel))]
[JsonSerializable(typeof(CqGroupSignInActionParamsModel))]
[JsonSerializable(typeof(CqHandleFriendRequestActionParamsModel))]
[JsonSerializable(typeof(CqHandleGroupRequestActionParamsModel))]
[JsonSerializable(typeof(CqKickGroupMemberActionParamsModel))]
[JsonSerializable(typeof(CqLeaveGroupActionParamsModel))]
[JsonSerializable(typeof(CqMarkMessageAsReadActionParamsModel))]
[JsonSerializable(typeof(CqOcrImageActionParamsModel))]
[JsonSerializable(typeof(CqRecallMessageActionParamsModel))]
[JsonSerializable(typeof(CqReloadEventFilterActionParamsModel))]
[JsonSerializable(typeof(CqSendGroupForwardMessageActionParamsModel))]
[JsonSerializable(typeof(CqSendGroupMessageActionParamsModel))]
[JsonSerializable(typeof(CqSendMessageActionParamsModel))]
[JsonSerializable(typeof(CqSendPrivateForwardMsgActionParamsModel))]
[JsonSerializable(typeof(CqSendPrivateMessageActionParamsModel))]
[JsonSerializable(typeof(CqSetAccountProfileActionParamsModel))]
[JsonSerializable(typeof(CqSetEssenceMessageActionParamsModel))]
[JsonSerializable(typeof(CqSetGroupAdministratorActionParamsModel))]
[JsonSerializable(typeof(CqSetGroupAnonymousActionParamsModel))]
[JsonSerializable(typeof(CqSetGroupAvatarActionParamsModel))]
[JsonSerializable(typeof(CqSetGroupNameActionParamsModel))]
[JsonSerializable(typeof(CqSetGroupNicknameActionParamsModel))]
[JsonSerializable(typeof(CqSetGroupSpecialTitleActionParamsModel))]
[JsonSerializable(typeof(CqSetModelShowActionParamsModel))]
[JsonSerializable(typeof(CqUploadGroupFileActionParamsModel))]
[JsonSerializable(typeof(CqUploadPrivateFileActionParamsModel))]

[JsonSerializable(typeof(CqActionResultDataModel))]
[JsonSerializable(typeof(CqBanGroupAllMembersActionResultDataModel))]
[JsonSerializable(typeof(CqBanGroupAnonymousMemberActionResultDataModel))]
[JsonSerializable(typeof(CqBanGroupMemberActionResultDataModel))]
[JsonSerializable(typeof(CqCanSendImageActionResultDataModel))]
[JsonSerializable(typeof(CqCanSendRecordActionResultDataModel))]
[JsonSerializable(typeof(CqCheckUrlSafetyActionResultDataModel))]
[JsonSerializable(typeof(CqCreateGroupFolderActionResultDataModel))]
[JsonSerializable(typeof(CqDeleteEssenceMessageActionResultDataModel))]
[JsonSerializable(typeof(CqDeleteFriendActionResultDataModel))]
[JsonSerializable(typeof(CqDeleteGroupFileActionResultDataModel))]
[JsonSerializable(typeof(CqDeleteGroupFolderActionResultDataModel))]
[JsonSerializable(typeof(CqDeleteUnidirectionalFriendActionResultDataModel))]
[JsonSerializable(typeof(CqDownloadFileActionResultDataModel))]
[JsonSerializable(typeof(CqGetCookiesActionResultDataModel))]
[JsonSerializable(typeof(CqGetCsrfTokenActionResultDataModel))]
[JsonSerializable(typeof(CqGetEssenceMessageListActionResultDataModel))]
[JsonSerializable(typeof(CqGetForwardMessageActionResultDataModel))]
[JsonSerializable(typeof(CqGetFriendListActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupFilesByFolderActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupFileSystemInformationActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupFileUrlActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupInformationActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupListActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupMemberInformationActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupMemberListActionResultDataModel))]
[JsonSerializable(typeof(CqGetGroupRootFilesActionResultDataModel))]
[JsonSerializable(typeof(CqGetImageActionResultDataModel))]
[JsonSerializable(typeof(CqGetLoginInformationActionResultDataModel))]
[JsonSerializable(typeof(CqGetMessageActionResultDataModel))]
[JsonSerializable(typeof(CqGetModelShowActionResultDataModel))]
[JsonSerializable(typeof(CqGetOnlineClientsActionResultDataModel))]
[JsonSerializable(typeof(CqGetStrangerInformationActionResultDataModel))]
[JsonSerializable(typeof(CqGetUnidirectionalFriendListActionResultDataModel))]
[JsonSerializable(typeof(CqGetVersionInformationActionResultDataModel))]
[JsonSerializable(typeof(CqGetWordSlicesActionResultDataModel))]
[JsonSerializable(typeof(CqGroupSignInActionResultDataModel))]
[JsonSerializable(typeof(CqHandleFriendRequestActionResultDataModel))]
[JsonSerializable(typeof(CqHandleGroupRequestActionResultDataModel))]
[JsonSerializable(typeof(CqKickGroupMemberActionResultDataModel))]
[JsonSerializable(typeof(CqLeaveGroupActionResultDataModel))]
[JsonSerializable(typeof(CqMarkMessageAsReadActionResultDataModel))]
[JsonSerializable(typeof(CqOcrImageActionResultDataModel))]
[JsonSerializable(typeof(CqRecallMessageActionResultDataModel))]
[JsonSerializable(typeof(CqReloadEventFilterActionResultDataModel))]
[JsonSerializable(typeof(CqSendGroupForwardMessageActionResultDataModel))]
[JsonSerializable(typeof(CqSendGroupMessageActionResultDataModel))]
[JsonSerializable(typeof(CqSendMessageActionResultDataModel))]
[JsonSerializable(typeof(CqSendPrivateForwardMessageActionResultDataModel))]
[JsonSerializable(typeof(CqSendPrivateMessageActionResultDataModel))]
[JsonSerializable(typeof(CqSetAccountProfileActionResultDataModel))]
[JsonSerializable(typeof(CqSetEssenceMessageActionResultDataModel))]
[JsonSerializable(typeof(CqSetGroupAdministratorActionResultDataModel))]
[JsonSerializable(typeof(CqSetGroupAnonymousActionResultDataModel))]
[JsonSerializable(typeof(CqSetGroupAvatarActionResultDataModel))]
[JsonSerializable(typeof(CqSetGroupNameActionResultDataModel))]
[JsonSerializable(typeof(CqSetGroupNicknameActionResultDataModel))]
[JsonSerializable(typeof(CqSetGroupSpecialTitleActionResultDataModel))]
[JsonSerializable(typeof(CqSetModelShowActionResultDataModel))]
[JsonSerializable(typeof(CqUploadGroupFileActionResultDataModel))]
[JsonSerializable(typeof(CqUploadPrivateFileActionResultDataModel))]
internal partial class JsonGeneratorSourceContext : JsonSerializerContext;
#endif