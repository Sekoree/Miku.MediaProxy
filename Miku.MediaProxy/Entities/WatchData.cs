using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NNDD.Entities
{
    public class WatchData
    {
        [JsonPropertyName("video")]
        public NndVideoApiDataVideo Video { get; set; }

        [JsonPropertyName("player")]
        public Player PlayerField { get; set; }

        [JsonPropertyName("thread")]
        public NndVideoApiDataThread Thread { get; set; }

        [JsonPropertyName("commentComposite")]
        public CommentComposite CommentCompositeField { get; set; }

        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

        [JsonPropertyName("playlist")]
        public object Playlist { get; set; }

        [JsonPropertyName("owner")]
        public Owner OwnerField { get; set; }

        [JsonPropertyName("viewer")]
        public Viewer ViewerField { get; set; }

        [JsonPropertyName("community")]
        public object Community { get; set; }

        [JsonPropertyName("mainCommunity")]
        public object MainCommunity { get; set; }

        [JsonPropertyName("channel")]
        public object Channel { get; set; }

        [JsonPropertyName("ad")]
        public Ad AdField { get; set; }

        [JsonPropertyName("lead")]
        public Lead LeadField { get; set; }

        [JsonPropertyName("maintenance")]
        public object Maintenance { get; set; }

        [JsonPropertyName("context")]
        public Context ContextField { get; set; }

        [JsonPropertyName("liveTopics")]
        public LiveTopics LiveTopicsField { get; set; }

        [JsonPropertyName("dataLayer")]
        public List<object> DataLayer { get; set; }

        [JsonPropertyName("watchRecommendationRecipe")]
        public string WatchRecommendationRecipe { get; set; }

        [JsonPropertyName("series")]
        public object Series { get; set; }

        [JsonPropertyName("wakutkool")]
        public object Wakutkool { get; set; }

        [JsonPropertyName("easyComment")]
        public EasyComment EasyCommentField { get; set; }

        public partial class Ad
        {
            [JsonPropertyName("vastMetaData")]
            public object VastMetaData { get; set; }

            [JsonPropertyName("vastReason")]
            public object VastReason { get; set; }
        }

        public partial class CommentComposite
        {
            [JsonPropertyName("threads")]
            public List<ThreadElement> Threads { get; set; }

            [JsonPropertyName("layers")]
            public List<Layer> Layers { get; set; }
        }

        public partial class Layer
        {
            [JsonPropertyName("index")]
            public long? Index { get; set; }

            [JsonPropertyName("isTranslucent")]
            public bool? IsTranslucent { get; set; }

            [JsonPropertyName("threadIds")]
            public List<ThreadId> ThreadIds { get; set; }
        }

        public partial class ThreadId
        {
            [JsonPropertyName("id")]
            public object Id { get; set; }

            [JsonPropertyName("fork")]
            public object Fork { get; set; }
        }

        public partial class ThreadElement
        {
            [JsonPropertyName("id")]
            public long? Id { get; set; }

            [JsonPropertyName("fork")]
            public long? Fork { get; set; }

            [JsonPropertyName("isActive")]
            public bool? IsActive { get; set; }

            [JsonPropertyName("postkeyStatus")]
            public long? PostkeyStatus { get; set; }

            [JsonPropertyName("isDefaultPostTarget")]
            public bool? IsDefaultPostTarget { get; set; }

            [JsonPropertyName("isThreadkeyRequired")]
            public bool? IsThreadkeyRequired { get; set; }

            [JsonPropertyName("isLeafRequired")]
            public bool? IsLeafRequired { get; set; }

            [JsonPropertyName("label")]
            public string Label { get; set; }

            [JsonPropertyName("isOwnerThread")]
            public bool? IsOwnerThread { get; set; }

            [JsonPropertyName("hasNicoscript")]
            public bool? HasNicoscript { get; set; }
        }

        public partial class Context
        {
            [JsonPropertyName("playFrom")]
            public object PlayFrom { get; set; }

            [JsonPropertyName("initialPlaybackPosition")]
            public long? InitialPlaybackPosition { get; set; }

            [JsonPropertyName("initialPlaybackType")]
            public string InitialPlaybackType { get; set; }

            [JsonPropertyName("playLength")]
            public object PlayLength { get; set; }

            [JsonPropertyName("returnId")]
            public object ReturnId { get; set; }

            [JsonPropertyName("returnTo")]
            public object ReturnTo { get; set; }

            [JsonPropertyName("returnMsg")]
            public object ReturnMsg { get; set; }

            [JsonPropertyName("watchId")]
            public string WatchId { get; set; }

            [JsonPropertyName("isNoMovie")]
            public object IsNoMovie { get; set; }

            [JsonPropertyName("isNoRelatedVideo")]
            public object IsNoRelatedVideo { get; set; }

            [JsonPropertyName("isDownloadCompleteWait")]
            public object IsDownloadCompleteWait { get; set; }

            [JsonPropertyName("isNoNicotic")]
            public object IsNoNicotic { get; set; }

            [JsonPropertyName("isNeedPayment")]
            public bool? IsNeedPayment { get; set; }

            [JsonPropertyName("isNeedAdmission")]
            public bool? IsNeedAdmission { get; set; }

            [JsonPropertyName("isPPV")]
            public bool? IsPpv { get; set; }

            [JsonPropertyName("isPremiumOnly")]
            public bool? IsPremiumOnly { get; set; }

            [JsonPropertyName("isAdultRatingNG")]
            public bool? IsAdultRatingNg { get; set; }

            [JsonPropertyName("isPlayable")]
            public object IsPlayable { get; set; }

            [JsonPropertyName("isTranslatable")]
            public bool? IsTranslatable { get; set; }

            [JsonPropertyName("isTagUneditable")]
            public bool? IsTagUneditable { get; set; }

            [JsonPropertyName("tagUneditableReason")]
            public object TagUneditableReason { get; set; }

            [JsonPropertyName("isVideoOwner")]
            public bool? IsVideoOwner { get; set; }

            [JsonPropertyName("isThreadOwner")]
            public bool? IsThreadOwner { get; set; }

            [JsonPropertyName("userCanShowEditorMenu")]
            public bool? UserCanShowEditorMenu { get; set; }

            [JsonPropertyName("isOwnerThreadEditable")]
            public object IsOwnerThreadEditable { get; set; }

            [JsonPropertyName("useChecklistCache")]
            public object UseChecklistCache { get; set; }

            [JsonPropertyName("isDisabledMarquee")]
            public object IsDisabledMarquee { get; set; }

            [JsonPropertyName("isDictionaryDisplayable")]
            public bool? IsDictionaryDisplayable { get; set; }

            [JsonPropertyName("isDefaultCommentInvisible")]
            public bool? IsDefaultCommentInvisible { get; set; }

            [JsonPropertyName("accessFrom")]
            public object AccessFrom { get; set; }

            [JsonPropertyName("csrfToken")]
            public string CsrfToken { get; set; }

            [JsonPropertyName("translationVersionJsonUpdateTime")]
            public long? TranslationVersionJsonUpdateTime { get; set; }

            [JsonPropertyName("userkey")]
            public string Userkey { get; set; }

            [JsonPropertyName("watchAuthKey")]
            public string WatchAuthKey { get; set; }

            [JsonPropertyName("watchTrackId")]
            public string WatchTrackId { get; set; }

            [JsonPropertyName("watchPageServerTime")]
            public long? WatchPageServerTime { get; set; }

            [JsonPropertyName("isAuthenticationRequired")]
            public bool? IsAuthenticationRequired { get; set; }

            [JsonPropertyName("isPeakTime")]
            public object IsPeakTime { get; set; }

            [JsonPropertyName("ngRevision")]
            public long? NgRevision { get; set; }

            [JsonPropertyName("yesterdayRank")]
            public object YesterdayRank { get; set; }

            [JsonPropertyName("highestRank")]
            public object HighestRank { get; set; }

            [JsonPropertyName("isMyMemory")]
            public bool? IsMyMemory { get; set; }

            [JsonPropertyName("ownerNGList")]
            public List<OwnerNgList> OwnerNgList { get; set; }

            [JsonPropertyName("linkedChannelVideos")]
            public object LinkedChannelVideos { get; set; }

            [JsonPropertyName("isAllowEmbedPlayer")]
            public bool? IsAllowEmbedPlayer { get; set; }

            [JsonPropertyName("genreName")]
            public string GenreName { get; set; }

            [JsonPropertyName("genreKey")]
            public string GenreKey { get; set; }

            [JsonPropertyName("representedTags")]
            public List<string> RepresentedTags { get; set; }

            [JsonPropertyName("isLiked")]
            public bool? IsLiked { get; set; }

            [JsonPropertyName("highestRepresentedTagRanking")]
            public List<HighestRepresentedTagRanking> HighestRepresentedTagRanking { get; set; }

            [JsonPropertyName("highestGenreRanking")]
            public HighestGenreRanking HighestGenreRanking { get; set; }
        }

        public partial class HighestGenreRanking
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("rank")]
            public long? Rank { get; set; }

            [JsonPropertyName("genre")]
            public string Genre { get; set; }

            [JsonPropertyName("dateTime")]
            public string DateTime { get; set; }
        }

        public partial class HighestRepresentedTagRanking
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("tag")]
            public string Tag { get; set; }

            [JsonPropertyName("regularizedTag")]
            public string RegularizedTag { get; set; }

            [JsonPropertyName("rank")]
            public long? Rank { get; set; }

            [JsonPropertyName("genre")]
            public string Genre { get; set; }

            [JsonPropertyName("dateTime")]
            public string DateTime { get; set; }
        }

        public partial class OwnerNgList
        {
            [JsonPropertyName("source")]
            public string Source { get; set; }

            [JsonPropertyName("destination")]
            public string Destination { get; set; }
        }

        public partial class EasyComment
        {
            [JsonPropertyName("phrases")]
            public List<Phrase> Phrases { get; set; }
        }

        public partial class Phrase
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }

            [JsonPropertyName("nicodic")]
            public Nicodic Nicodic { get; set; }
        }

        public partial class Nicodic
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("viewTitle")]
            public string ViewTitle { get; set; }

            [JsonPropertyName("summary")]
            public string Summary { get; set; }

            [JsonPropertyName("link")]
            public Uri Link { get; set; }
        }

        public partial class Lead
        {
            [JsonPropertyName("tagRelatedMarquee")]
            public object TagRelatedMarquee { get; set; }

            [JsonPropertyName("tagRelatedBanner")]
            public object TagRelatedBanner { get; set; }

            [JsonPropertyName("videoEndBannerIn")]
            public object VideoEndBannerIn { get; set; }

            [JsonPropertyName("videoEndOverlay")]
            public object VideoEndOverlay { get; set; }
        }

        public partial class LiveTopics
        {
            [JsonPropertyName("items")]
            public List<Item> Items { get; set; }
        }

        public partial class Item
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("thumbnailURL")]
            public Uri ThumbnailUrl { get; set; }

            [JsonPropertyName("point")]
            public long? Point { get; set; }

            [JsonPropertyName("isHigh")]
            public bool? IsHigh { get; set; }

            [JsonPropertyName("elapsedTimeM")]
            public long? ElapsedTimeM { get; set; }

            [JsonPropertyName("communityId")]
            public string CommunityId { get; set; }

            [JsonPropertyName("communityName")]
            public string CommunityName { get; set; }
        }

        public partial class Owner
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("nickname")]
            public string Nickname { get; set; }

            [JsonPropertyName("iconURL")]
            public Uri IconUrl { get; set; }

            [JsonPropertyName("nicoliveInfo")]
            public object NicoliveInfo { get; set; }

            [JsonPropertyName("channelInfo")]
            public object ChannelInfo { get; set; }

            [JsonPropertyName("isUserVideoPublic")]
            public bool? IsUserVideoPublic { get; set; }

            [JsonPropertyName("isUserMyVideoPublic")]
            public bool? IsUserMyVideoPublic { get; set; }

            [JsonPropertyName("isUserOpenListPublic")]
            public bool? IsUserOpenListPublic { get; set; }
        }

        public partial class Player
        {
            [JsonPropertyName("playerInfoXMLUpdateTIme")]
            public long? PlayerInfoXmlUpdateTIme { get; set; }

            [JsonPropertyName("isContinuous")]
            public bool? IsContinuous { get; set; }
        }

        public partial class Tag
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("isCategory")]
            public bool? IsCategory { get; set; }

            [JsonPropertyName("isCategoryCandidate")]
            public bool? IsCategoryCandidate { get; set; }

            [JsonPropertyName("isDictionaryExists")]
            public bool? IsDictionaryExists { get; set; }

            [JsonPropertyName("isLocked")]
            public bool? IsLocked { get; set; }

            [JsonPropertyName("isRepresentedTag")]
            public bool? IsRepresentedTag { get; set; }
        }

        public partial class NndVideoApiDataThread
        {
            [JsonPropertyName("commentCount")]
            public long? CommentCount { get; set; }

            [JsonPropertyName("hasOwnerThread")]
            public object HasOwnerThread { get; set; }

            [JsonPropertyName("mymemoryLanguage")]
            public object MymemoryLanguage { get; set; }

            [JsonPropertyName("serverUrl")]
            public Uri ServerUrl { get; set; }

            [JsonPropertyName("subServerUrl")]
            public Uri SubServerUrl { get; set; }

            [JsonPropertyName("ids")]
            public Ids Ids { get; set; }
        }

        public partial class Ids
        {
            [JsonPropertyName("default")]
            public string Default { get; set; }

            [JsonPropertyName("nicos")]
            public object Nicos { get; set; }

            [JsonPropertyName("community")]
            public object Community { get; set; }
        }

        public partial class NndVideoApiDataVideo
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("originalTitle")]
            public string OriginalTitle { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("originalDescription")]
            public string OriginalDescription { get; set; }

            [JsonPropertyName("thumbnailURL")]
            public Uri ThumbnailUrl { get; set; }

            [JsonPropertyName("largeThumbnailURL")]
            public Uri LargeThumbnailUrl { get; set; }

            [JsonPropertyName("postedDateTime")]
            public string PostedDateTime { get; set; }

            [JsonPropertyName("originalPostedDateTime")]
            public object OriginalPostedDateTime { get; set; }

            [JsonPropertyName("width")]
            public object Width { get; set; }

            [JsonPropertyName("height")]
            public object Height { get; set; }

            [JsonPropertyName("duration")]
            public double? Duration { get; set; }

            [JsonPropertyName("viewCount")]
            public long? ViewCount { get; set; }

            [JsonPropertyName("mylistCount")]
            public long? MylistCount { get; set; }

            [JsonPropertyName("translation")]
            public object Translation { get; set; }

            [JsonPropertyName("translator")]
            public object Translator { get; set; }

            [JsonPropertyName("movieType")]
            public string MovieType { get; set; }

            [JsonPropertyName("badges")]
            public object Badges { get; set; }

            [JsonPropertyName("mainCommunityId")]
            public object MainCommunityId { get; set; }

            [JsonPropertyName("dmcInfo")]
            public DmcInfo DmcInfo { get; set; }

            [JsonPropertyName("backCommentType")]
            public object BackCommentType { get; set; }

            [JsonPropertyName("channelId")]
            public object ChannelId { get; set; }

            [JsonPropertyName("isCommentExpired")]
            public bool? IsCommentExpired { get; set; }

            [JsonPropertyName("isWide")]
            public object IsWide { get; set; }

            [JsonPropertyName("isOfficialAnime")]
            public object IsOfficialAnime { get; set; }

            [JsonPropertyName("isDeleted")]
            public bool? IsDeleted { get; set; }

            [JsonPropertyName("isTranslated")]
            public bool? IsTranslated { get; set; }

            [JsonPropertyName("isR18")]
            public bool? IsR18 { get; set; }

            [JsonPropertyName("isAdult")]
            public bool? IsAdult { get; set; }

            [JsonPropertyName("isNicowari")]
            public object IsNicowari { get; set; }

            [JsonPropertyName("isPublic")]
            public bool? IsPublic { get; set; }

            [JsonPropertyName("isPublishedNicoscript")]
            public object IsPublishedNicoscript { get; set; }

            [JsonPropertyName("isNoNGS")]
            public object IsNoNgs { get; set; }

            [JsonPropertyName("isCommunityMemberOnly")]
            public string IsCommunityMemberOnly { get; set; }

            [JsonPropertyName("isCommonsTreeExists")]
            public bool? IsCommonsTreeExists { get; set; }

            [JsonPropertyName("isNoIchiba")]
            public bool? IsNoIchiba { get; set; }

            [JsonPropertyName("isOfficial")]
            public bool? IsOfficial { get; set; }

            [JsonPropertyName("isMonetized")]
            public bool? IsMonetized { get; set; }

            [JsonPropertyName("smileInfo")]
            public SmileInfo SmileInfo { get; set; }

            [JsonPropertyName("likedCount")]
            public object LikedCount { get; set; }
        }

        public partial class DmcInfo
        {
            [JsonPropertyName("time")]
            public long? Time { get; set; }

            [JsonPropertyName("time_ms")]
            public long? TimeMs { get; set; }

            [JsonPropertyName("video")]
            public DmcInfoVideo Video { get; set; }

            [JsonPropertyName("thread")]
            public DmcInfoThread Thread { get; set; }

            [JsonPropertyName("user")]
            public User User { get; set; }

            [JsonPropertyName("import_version")]
            public long? ImportVersion { get; set; }

            [JsonPropertyName("error")]
            public object Error { get; set; }

            [JsonPropertyName("tracking_id")]
            public string TrackingId { get; set; }

            [JsonPropertyName("session_api")]
            public SessionApi SessionApi { get; set; }

            [JsonPropertyName("storyboard_session_api")]
            public StoryboardSessionApi StoryboardSessionApi { get; set; }

            [JsonPropertyName("quality")]
            public Quality Quality { get; set; }
        }

        public partial class Quality
        {
            [JsonPropertyName("videos")]
            public List<VideoElement> Videos { get; set; }

            [JsonPropertyName("audios")]
            public List<Audio> Audios { get; set; }
        }

        public partial class Audio
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("available")]
            public bool? Available { get; set; }

            [JsonPropertyName("bitrate")]
            public long? Bitrate { get; set; }

            [JsonPropertyName("sampling_rate")]
            public long? SamplingRate { get; set; }

            [JsonPropertyName("loudness")]
            public Loudness Loudness { get; set; }

            [JsonPropertyName("loudness_correction_value")]
            public List<LoudnessCorrectionValue> LoudnessCorrectionValue { get; set; }
        }

        public partial class Loudness
        {
            [JsonPropertyName("integratedLoudness")]
            public double? IntegratedLoudness { get; set; }

            [JsonPropertyName("truePeak")]
            public decimal? TruePeak { get; set; }
        }

        public partial class LoudnessCorrectionValue
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("value")]
            public double? Value { get; set; }
        }

        public partial class VideoElement
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("level_index")]
            public long? LevelIndex { get; set; }

            [JsonPropertyName("available")]
            public bool? Available { get; set; }

            [JsonPropertyName("bitrate")]
            public long? Bitrate { get; set; }

            [JsonPropertyName("resolution")]
            public Resolution Resolution { get; set; }

            [JsonPropertyName("label")]
            public string Label { get; set; }
        }

        public partial class Resolution
        {
            [JsonPropertyName("width")]
            public long? Width { get; set; }

            [JsonPropertyName("height")]
            public long? Height { get; set; }
        }

        public partial class SessionApi
        {
            [JsonPropertyName("recipe_id")]
            public string RecipeId { get; set; }

            [JsonPropertyName("player_id")]
            public string PlayerId { get; set; }

            [JsonPropertyName("videos")]
            public List<string> Videos { get; set; }

            [JsonPropertyName("audios")]
            public List<string> Audios { get; set; }

            [JsonPropertyName("movies")]
            public List<object> Movies { get; set; }

            [JsonPropertyName("protocols")]
            public List<string> Protocols { get; set; }

            [JsonPropertyName("auth_types")]
            public SessionApiAuthTypes AuthTypes { get; set; }

            [JsonPropertyName("service_user_id")]
            public string ServiceUserId { get; set; }

            [JsonPropertyName("token")]
            public string Token { get; set; }

            [JsonPropertyName("signature")]
            public string Signature { get; set; }

            [JsonPropertyName("content_id")]
            public string ContentId { get; set; }

            [JsonPropertyName("heartbeat_lifetime")]
            public long? HeartbeatLifetime { get; set; }

            [JsonPropertyName("content_key_timeout")]
            public long? ContentKeyTimeout { get; set; }

            [JsonPropertyName("priority")]
            public double? Priority { get; set; }

            [JsonPropertyName("transfer_presets")]
            public List<string> TransferPresets { get; set; }

            [JsonPropertyName("urls")]
            public List<Url> Urls { get; set; }
        }

        public partial class SessionApiAuthTypes
        {
            [JsonPropertyName("http")]
            public string Http { get; set; }

            [JsonPropertyName("hls")]
            public string Hls { get; set; }
        }

        public partial class Url
        {
            [JsonPropertyName("url")]
            public Uri UrlField { get; set; }

            [JsonPropertyName("is_well_known_port")]
            public bool? IsWellKnownPort { get; set; }

            [JsonPropertyName("is_ssl")]
            public bool? IsSsl { get; set; }
        }

        public partial class StoryboardSessionApi
        {
            [JsonPropertyName("recipe_id")]
            public string RecipeId { get; set; }

            [JsonPropertyName("player_id")]
            public string PlayerId { get; set; }

            [JsonPropertyName("videos")]
            public List<string> Videos { get; set; }

            [JsonPropertyName("audios")]
            public List<object> Audios { get; set; }

            [JsonPropertyName("movies")]
            public List<object> Movies { get; set; }

            [JsonPropertyName("protocols")]
            public List<string> Protocols { get; set; }

            [JsonPropertyName("auth_types")]
            public StoryboardSessionApiAuthTypes AuthTypes { get; set; }

            [JsonPropertyName("service_user_id")]
            public string ServiceUserId { get; set; }

            [JsonPropertyName("token")]
            public string Token { get; set; }

            [JsonPropertyName("signature")]
            public string Signature { get; set; }

            [JsonPropertyName("content_id")]
            public string ContentId { get; set; }

            [JsonPropertyName("heartbeat_lifetime")]
            public long? HeartbeatLifetime { get; set; }

            [JsonPropertyName("content_key_timeout")]
            public long? ContentKeyTimeout { get; set; }

            [JsonPropertyName("priority")]
            public double? Priority { get; set; }

            [JsonPropertyName("transfer_presets")]
            public List<object> TransferPresets { get; set; }

            [JsonPropertyName("urls")]
            public List<Url> Urls { get; set; }
        }

        public partial class StoryboardSessionApiAuthTypes
        {
            [JsonPropertyName("storyboard")]
            public string Storyboard { get; set; }
        }

        public partial class DmcInfoThread
        {
            [JsonPropertyName("server_url")]
            public Uri ServerUrl { get; set; }

            [JsonPropertyName("sub_server_url")]
            public Uri SubServerUrl { get; set; }

            [JsonPropertyName("thread_id")]
            public object ThreadId { get; set; }

            [JsonPropertyName("nicos_thread_id")]
            public object NicosThreadId { get; set; }

            [JsonPropertyName("optional_thread_id")]
            public object OptionalThreadId { get; set; }

            [JsonPropertyName("thread_key_required")]
            public bool? ThreadKeyRequired { get; set; }

            [JsonPropertyName("channel_ng_words")]
            public List<object> ChannelNgWords { get; set; }

            [JsonPropertyName("owner_ng_words")]
            public List<object> OwnerNgWords { get; set; }

            [JsonPropertyName("maintenances_ng")]
            public bool? MaintenancesNg { get; set; }

            [JsonPropertyName("postkey_available")]
            public bool? PostkeyAvailable { get; set; }

            [JsonPropertyName("ng_revision")]
            public long? NgRevision { get; set; }
        }

        public partial class User
        {
            [JsonPropertyName("user_id")]
            public long? UserId { get; set; }

            [JsonPropertyName("is_premium")]
            public bool? IsPremium { get; set; }

            [JsonPropertyName("nickname")]
            public string Nickname { get; set; }
        }

        public partial class DmcInfoVideo
        {
            [JsonPropertyName("video_id")]
            public string VideoId { get; set; }

            [JsonPropertyName("length_seconds")]
            public long? LengthSeconds { get; set; }

            [JsonPropertyName("deleted")]
            public long? Deleted { get; set; }
        }

        public partial class SmileInfo
        {
            [JsonPropertyName("url")]
            public Uri Url { get; set; }

            [JsonPropertyName("isSlowLine")]
            public bool? IsSlowLine { get; set; }

            [JsonPropertyName("currentQualityId")]
            public string CurrentQualityId { get; set; }

            [JsonPropertyName("qualityIds")]
            public List<string> QualityIds { get; set; }

            [JsonPropertyName("loudnessCorrectionValue")]
            public List<LoudnessCorrectionValue> LoudnessCorrectionValue { get; set; }
        }

        public partial class Viewer
        {
            [JsonPropertyName("id")]
            public long? Id { get; set; }

            [JsonPropertyName("nickname")]
            public string Nickname { get; set; }

            [JsonPropertyName("prefecture")]
            public long? Prefecture { get; set; }

            [JsonPropertyName("sex")]
            public long? Sex { get; set; }

            [JsonPropertyName("age")]
            public long? Age { get; set; }

            [JsonPropertyName("isPremium")]
            public bool? IsPremium { get; set; }

            [JsonPropertyName("isPostLocked")]
            public bool? IsPostLocked { get; set; }

            [JsonPropertyName("isHtrzm")]
            public bool? IsHtrzm { get; set; }

            [JsonPropertyName("isTwitterConnection")]
            public bool? IsTwitterConnection { get; set; }

            [JsonPropertyName("isBicentennial")]
            public bool? IsBicentennial { get; set; }

            [JsonPropertyName("nicosid")]
            public string Nicosid { get; set; }
        }
    }
}
