using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Miku.MP.Test
{
    public class YoutubeVideo
    {
        [JsonPropertyName("responseContext")]
        public ResponseContext ResponseContextField { get; set; }

        [JsonPropertyName("playabilityStatus")]
        public PlayabilityStatus PlayabilityStatusField { get; set; }

        [JsonPropertyName("streamingData")]
        public StreamingData StreamingDataField { get; set; }

        [JsonPropertyName("playbackTracking")]
        public PlaybackTracking PlaybackTrackingField { get; set; }

        [JsonPropertyName("captions")]
        public Captions CaptionsField { get; set; }

        [JsonPropertyName("videoDetails")]
        public VideoDetails VideoDetailsField { get; set; }

        [JsonPropertyName("playerConfig")]
        public PlayerConfig PlayerConfigField { get; set; }

        [JsonPropertyName("storyboards")]
        public Storyboards StoryboardsField { get; set; }

        [JsonPropertyName("microformat")]
        public Microformat MicroformatField { get; set; }

        [JsonPropertyName("trackingParams")]
        public string TrackingParams { get; set; }

        [JsonPropertyName("attestation")]
        public Attestation AttestationField { get; set; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

        [JsonPropertyName("auxiliaryUi")]
        public AuxiliaryUi AuxiliaryUiField { get; set; }

        public partial class Attestation
        {
            [JsonPropertyName("playerAttestationRenderer")]
            public PlayerAttestationRenderer PlayerAttestationRenderer { get; set; }
        }

        public partial class PlayerAttestationRenderer
        {
            [JsonPropertyName("challenge")]
            public string Challenge { get; set; }

            [JsonPropertyName("botguardData")]
            public BotguardData BotguardData { get; set; }
        }

        public partial class BotguardData
        {
            [JsonPropertyName("program")]
            public string Program { get; set; }

            [JsonPropertyName("interpreterUrl")]
            public string InterpreterUrl { get; set; }
        }

        public partial class AuxiliaryUi
        {
            [JsonPropertyName("messageRenderers")]
            public MessageRenderers MessageRenderers { get; set; }
        }

        public partial class MessageRenderers
        {
            [JsonPropertyName("upsellDialogRenderer")]
            public UpsellDialogRenderer UpsellDialogRenderer { get; set; }
        }

        public partial class UpsellDialogRenderer
        {
            [JsonPropertyName("trackingParams")]
            public string TrackingParams { get; set; }

            [JsonPropertyName("headerBackgroundImage")]
            public HeaderBackgroundImageClass HeaderBackgroundImage { get; set; }

            [JsonPropertyName("dialogMessageTitle")]
            public DialogMessageTitle DialogMessageTitle { get; set; }

            [JsonPropertyName("dialogMessageText")]
            public DialogMessageText DialogMessageText { get; set; }

            [JsonPropertyName("impressionEndpoint")]
            public Endpoint ImpressionEndpoint { get; set; }

            [JsonPropertyName("actionButton")]
            public ActionButton ActionButton { get; set; }

            [JsonPropertyName("dismissButton")]
            public Button DismissButton { get; set; }

            [JsonPropertyName("impressionEndpoints")]
            public List<Endpoint> ImpressionEndpoints { get; set; }

            [JsonPropertyName("isVisible")]
            public bool? IsVisible { get; set; }

            [JsonPropertyName("upsellDialogTriggerConditionSupportedDatas")]
            public UpsellDialogTriggerConditionSupportedDatas UpsellDialogTriggerConditionSupportedDatas { get; set; }

            [JsonPropertyName("dialogIcon")]
            public Icon DialogIcon { get; set; }

            [JsonPropertyName("popupSize")]
            public string PopupSize { get; set; }

            [JsonPropertyName("layout")]
            public string Layout { get; set; }

            [JsonPropertyName("dismissStrategy")]
            public string DismissStrategy { get; set; }
        }

        public partial class ActionButton
        {
            [JsonPropertyName("buttonRenderer")]
            public PurpleButtonRenderer ButtonRenderer { get; set; }
        }

        public partial class PurpleButtonRenderer
        {
            [JsonPropertyName("style")]
            public string Style { get; set; }

            [JsonPropertyName("size")]
            public string Size { get; set; }

            [JsonPropertyName("text")]
            public DialogMessageTitle Text { get; set; }

            [JsonPropertyName("serviceEndpoint")]
            public Endpoint ServiceEndpoint { get; set; }

            [JsonPropertyName("icon")]
            public Icon Icon { get; set; }

            [JsonPropertyName("navigationEndpoint")]
            public PurpleNavigationEndpoint NavigationEndpoint { get; set; }

            [JsonPropertyName("trackingParams")]
            public string TrackingParams { get; set; }
        }

        public partial class Icon
        {
            [JsonPropertyName("iconType")]
            public string IconType { get; set; }
        }

        public partial class PurpleNavigationEndpoint
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public NavigationEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("signInEndpoint")]
            public SignInEndpoint SignInEndpoint { get; set; }
        }

        public partial class NavigationEndpointCommandMetadata
        {
            [JsonPropertyName("webCommandMetadata")]
            public PurpleWebCommandMetadata WebCommandMetadata { get; set; }
        }

        public partial class PurpleWebCommandMetadata
        {
            [JsonPropertyName("url")]
            public Uri Url { get; set; }

            [JsonPropertyName("webPageType")]
            public string WebPageType { get; set; }

            [JsonPropertyName("rootVe")]
            public long? RootVe { get; set; }
        }

        public partial class SignInEndpoint
        {
            [JsonPropertyName("hack")]
            public bool? Hack { get; set; }

            [JsonPropertyName("gaeParam")]
            public string GaeParam { get; set; }
        }

        public partial class Endpoint
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public ImpressionEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("feedbackEndpoint")]
            public FeedbackEndpoint FeedbackEndpoint { get; set; }
        }

        public partial class ImpressionEndpointCommandMetadata
        {
            [JsonPropertyName("webCommandMetadata")]
            public FluffyWebCommandMetadata WebCommandMetadata { get; set; }
        }

        public partial class FluffyWebCommandMetadata
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("sendPost")]
            public bool? SendPost { get; set; }

            [JsonPropertyName("apiUrl")]
            public string ApiUrl { get; set; }
        }

        public partial class FeedbackEndpoint
        {
            [JsonPropertyName("feedbackToken")]
            public string FeedbackToken { get; set; }

            [JsonPropertyName("uiActions")]
            public UiActions UiActions { get; set; }
        }

        public partial class UiActions
        {
            [JsonPropertyName("hideEnclosingContainer")]
            public bool? HideEnclosingContainer { get; set; }
        }

        public partial class DialogMessageTitle
        {
            [JsonPropertyName("runs")]
            public List<DialogMessageTitleRun> Runs { get; set; }
        }

        public partial class DialogMessageTitleRun
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }
        }

        public partial class DialogMessageText
        {
            [JsonPropertyName("runs")]
            public List<DialogMessageTextRun> Runs { get; set; }
        }

        public partial class DialogMessageTextRun
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }

            [JsonPropertyName("navigationEndpoint")]
            public RunNavigationEndpoint NavigationEndpoint { get; set; }
        }

        public partial class RunNavigationEndpoint
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public NavigationEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("applicationHelpEndpoint")]
            public ApplicationHelpEndpoint ApplicationHelpEndpoint { get; set; }
        }

        public partial class ApplicationHelpEndpoint
        {
            [JsonPropertyName("helpContext")]
            public string HelpContext { get; set; }
        }

        public partial class Button
        {
            [JsonPropertyName("buttonRenderer")]
            public DismissButtonButtonRenderer ButtonRenderer { get; set; }
        }

        public partial class DismissButtonButtonRenderer
        {
            [JsonPropertyName("style")]
            public string Style { get; set; }

            [JsonPropertyName("size")]
            public string Size { get; set; }

            [JsonPropertyName("text")]
            public DialogMessageTitle Text { get; set; }

            [JsonPropertyName("serviceEndpoint")]
            public Endpoint ServiceEndpoint { get; set; }

            [JsonPropertyName("trackingParams")]
            public string TrackingParams { get; set; }

            [JsonPropertyName("navigationEndpoint")]
            public FluffyNavigationEndpoint NavigationEndpoint { get; set; }
        }

        public partial class FluffyNavigationEndpoint
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public NavigationEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("urlEndpoint")]
            public UrlEndpoint UrlEndpoint { get; set; }
        }

        public partial class UrlEndpoint
        {
            [JsonPropertyName("url")]
            public Uri Url { get; set; }

            [JsonPropertyName("target")]
            public string Target { get; set; }
        }

        public partial class HeaderBackgroundImageClass
        {
            [JsonPropertyName("thumbnails")]
            public List<ThumbnailElement> Thumbnails { get; set; }
        }

        public partial class ThumbnailElement
        {
            [JsonPropertyName("url")]
            public Uri Url { get; set; }

            [JsonPropertyName("width")]
            public long? Width { get; set; }

            [JsonPropertyName("height")]
            public long? Height { get; set; }
        }

        public partial class UpsellDialogTriggerConditionSupportedDatas
        {
            [JsonPropertyName("playbackUpsellDialogTriggerConditionData")]
            public PlaybackUpsellDialogTriggerConditionData PlaybackUpsellDialogTriggerConditionData { get; set; }
        }

        public partial class PlaybackUpsellDialogTriggerConditionData
        {
            [JsonPropertyName("triggerType")]
            public string TriggerType { get; set; }
        }

        public partial class Captions
        {
            [JsonPropertyName("playerCaptionsRenderer")]
            public PlayerCaptionsRenderer PlayerCaptionsRenderer { get; set; }

            [JsonPropertyName("playerCaptionsTracklistRenderer")]
            public PlayerCaptionsTracklistRenderer PlayerCaptionsTracklistRenderer { get; set; }
        }

        public partial class PlayerCaptionsRenderer
        {
            [JsonPropertyName("baseUrl")]
            public Uri BaseUrl { get; set; }

            [JsonPropertyName("visibility")]
            public string Visibility { get; set; }
        }

        public partial class PlayerCaptionsTracklistRenderer
        {
            [JsonPropertyName("captionTracks")]
            public List<CaptionTrack> CaptionTracks { get; set; }

            [JsonPropertyName("audioTracks")]
            public List<AudioTrack> AudioTracks { get; set; }

            [JsonPropertyName("translationLanguages")]
            public List<TranslationLanguage> TranslationLanguages { get; set; }

            [JsonPropertyName("defaultAudioTrackIndex")]
            public long? DefaultAudioTrackIndex { get; set; }
        }

        public partial class AudioTrack
        {
            [JsonPropertyName("captionTrackIndices")]
            public List<long> CaptionTrackIndices { get; set; }

            [JsonPropertyName("defaultCaptionTrackIndex")]
            public long? DefaultCaptionTrackIndex { get; set; }

            [JsonPropertyName("visibility")]
            public string Visibility { get; set; }

            [JsonPropertyName("hasDefaultTrack")]
            public bool? HasDefaultTrack { get; set; }
        }

        public partial class CaptionTrack
        {
            [JsonPropertyName("baseUrl")]
            public Uri BaseUrl { get; set; }

            [JsonPropertyName("name")]
            public Description Name { get; set; }

            [JsonPropertyName("vssId")]
            public string VssId { get; set; }

            [JsonPropertyName("languageCode")]
            public string LanguageCode { get; set; }

            [JsonPropertyName("isTranslatable")]
            public bool? IsTranslatable { get; set; }
        }

        public partial class Description
        {
            [JsonPropertyName("simpleText")]
            public string SimpleText { get; set; }
        }

        public partial class TranslationLanguage
        {
            [JsonPropertyName("languageCode")]
            public string LanguageCode { get; set; }

            [JsonPropertyName("languageName")]
            public Description LanguageName { get; set; }
        }

        public partial class Message
        {
            [JsonPropertyName("mealbarPromoRenderer")]
            public MealbarPromoRenderer MealbarPromoRenderer { get; set; }
        }

        public partial class MealbarPromoRenderer
        {
            [JsonPropertyName("messageTexts")]
            public List<DialogMessageTitle> MessageTexts { get; set; }

            [JsonPropertyName("actionButton")]
            public Button ActionButton { get; set; }

            [JsonPropertyName("dismissButton")]
            public Button DismissButton { get; set; }

            [JsonPropertyName("triggerCondition")]
            public string TriggerCondition { get; set; }

            [JsonPropertyName("style")]
            public string Style { get; set; }

            [JsonPropertyName("trackingParams")]
            public string TrackingParams { get; set; }

            [JsonPropertyName("impressionEndpoints")]
            public List<Endpoint> ImpressionEndpoints { get; set; }

            [JsonPropertyName("isVisible")]
            public bool? IsVisible { get; set; }

            [JsonPropertyName("messageTitle")]
            public DialogMessageTitle MessageTitle { get; set; }
        }

        public partial class Microformat
        {
            [JsonPropertyName("playerMicroformatRenderer")]
            public PlayerMicroformatRenderer PlayerMicroformatRenderer { get; set; }
        }

        public partial class PlayerMicroformatRenderer
        {
            [JsonPropertyName("thumbnail")]
            public HeaderBackgroundImageClass Thumbnail { get; set; }

            [JsonPropertyName("embed")]
            public Embed Embed { get; set; }

            [JsonPropertyName("title")]
            public Description Title { get; set; }

            [JsonPropertyName("description")]
            public Description Description { get; set; }

            [JsonPropertyName("lengthSeconds")]
            public string LengthSeconds { get; set; }

            [JsonPropertyName("ownerProfileUrl")]
            public Uri OwnerProfileUrl { get; set; }

            [JsonPropertyName("externalChannelId")]
            public string ExternalChannelId { get; set; }

            [JsonPropertyName("availableCountries")]
            public List<string> AvailableCountries { get; set; }

            [JsonPropertyName("isUnlisted")]
            public bool? IsUnlisted { get; set; }

            [JsonPropertyName("hasYpcMetadata")]
            public bool? HasYpcMetadata { get; set; }

            [JsonPropertyName("viewCount")]
            public string ViewCount { get; set; }

            [JsonPropertyName("category")]
            public string Category { get; set; }

            [JsonPropertyName("publishDate")]
            public DateTimeOffset? PublishDate { get; set; }

            [JsonPropertyName("ownerChannelName")]
            public string OwnerChannelName { get; set; }

            [JsonPropertyName("uploadDate")]
            public DateTimeOffset? UploadDate { get; set; }
        }

        public partial class Embed
        {
            [JsonPropertyName("iframeUrl")]
            public Uri IframeUrl { get; set; }

            [JsonPropertyName("flashUrl")]
            public Uri FlashUrl { get; set; }

            [JsonPropertyName("width")]
            public long? Width { get; set; }

            [JsonPropertyName("height")]
            public long? Height { get; set; }

            [JsonPropertyName("flashSecureUrl")]
            public Uri FlashSecureUrl { get; set; }
        }

        public partial class PlayabilityStatus
        {
            [JsonPropertyName("status")]
            public string Status { get; set; }

            [JsonPropertyName("playableInEmbed")]
            public bool? PlayableInEmbed { get; set; }

            [JsonPropertyName("miniplayer")]
            public Miniplayer Miniplayer { get; set; }

            [JsonPropertyName("contextParams")]
            public string ContextParams { get; set; }
        }

        public partial class Miniplayer
        {
            [JsonPropertyName("miniplayerRenderer")]
            public MiniplayerRenderer MiniplayerRenderer { get; set; }
        }

        public partial class MiniplayerRenderer
        {
            [JsonPropertyName("playbackMode")]
            public string PlaybackMode { get; set; }
        }

        public partial class PlaybackTracking
        {
            [JsonPropertyName("videostatsPlaybackUrl")]
            public PtrackingUrlClass VideostatsPlaybackUrl { get; set; }

            [JsonPropertyName("videostatsDelayplayUrl")]
            public PtrackingUrlClass VideostatsDelayplayUrl { get; set; }

            [JsonPropertyName("videostatsWatchtimeUrl")]
            public PtrackingUrlClass VideostatsWatchtimeUrl { get; set; }

            [JsonPropertyName("ptrackingUrl")]
            public PtrackingUrlClass PtrackingUrl { get; set; }

            [JsonPropertyName("qoeUrl")]
            public PtrackingUrlClass QoeUrl { get; set; }

            [JsonPropertyName("setAwesomeUrl")]
            public AtrUrlClass SetAwesomeUrl { get; set; }

            [JsonPropertyName("atrUrl")]
            public AtrUrlClass AtrUrl { get; set; }
        }

        public partial class AtrUrlClass
        {
            [JsonPropertyName("baseUrl")]
            public Uri BaseUrl { get; set; }

            [JsonPropertyName("elapsedMediaTimeSeconds")]
            public long? ElapsedMediaTimeSeconds { get; set; }
        }

        public partial class PtrackingUrlClass
        {
            [JsonPropertyName("baseUrl")]
            public Uri BaseUrl { get; set; }
        }

        public partial class PlayerConfig
        {
            [JsonPropertyName("audioConfig")]
            public AudioConfig AudioConfig { get; set; }

            [JsonPropertyName("streamSelectionConfig")]
            public StreamSelectionConfig StreamSelectionConfig { get; set; }

            [JsonPropertyName("daiConfig")]
            public DaiConfig DaiConfig { get; set; }

            [JsonPropertyName("mediaCommonConfig")]
            public MediaCommonConfig MediaCommonConfig { get; set; }

            [JsonPropertyName("webPlayerConfig")]
            public WebPlayerConfig WebPlayerConfig { get; set; }
        }

        public partial class AudioConfig
        {
            [JsonPropertyName("loudnessDb")]
            public double? LoudnessDb { get; set; }

            [JsonPropertyName("perceptualLoudnessDb")]
            public double? PerceptualLoudnessDb { get; set; }

            [JsonPropertyName("enablePerFormatLoudness")]
            public bool? EnablePerFormatLoudness { get; set; }
        }

        public partial class DaiConfig
        {
            [JsonPropertyName("enableServerStitchedDai")]
            public bool? EnableServerStitchedDai { get; set; }
        }

        public partial class MediaCommonConfig
        {
            [JsonPropertyName("dynamicReadaheadConfig")]
            public DynamicReadaheadConfig DynamicReadaheadConfig { get; set; }
        }

        public partial class DynamicReadaheadConfig
        {
            [JsonPropertyName("maxReadAheadMediaTimeMs")]
            public long? MaxReadAheadMediaTimeMs { get; set; }

            [JsonPropertyName("minReadAheadMediaTimeMs")]
            public long? MinReadAheadMediaTimeMs { get; set; }

            [JsonPropertyName("readAheadGrowthRateMs")]
            public long? ReadAheadGrowthRateMs { get; set; }
        }

        public partial class StreamSelectionConfig
        {
            [JsonPropertyName("maxBitrate")]
            public string MaxBitrate { get; set; }
        }

        public partial class WebPlayerConfig
        {
            [JsonPropertyName("webPlayerActionsPorting")]
            public WebPlayerActionsPorting WebPlayerActionsPorting { get; set; }
        }

        public partial class WebPlayerActionsPorting
        {
            [JsonPropertyName("getSharePanelCommand")]
            public GetSharePanelCommand GetSharePanelCommand { get; set; }

            [JsonPropertyName("subscribeCommand")]
            public SubscribeCommand SubscribeCommand { get; set; }

            [JsonPropertyName("unsubscribeCommand")]
            public UnsubscribeCommand UnsubscribeCommand { get; set; }

            [JsonPropertyName("addToWatchLaterCommand")]
            public AddToWatchLaterCommand AddToWatchLaterCommand { get; set; }

            [JsonPropertyName("removeFromWatchLaterCommand")]
            public RemoveFromWatchLaterCommand RemoveFromWatchLaterCommand { get; set; }
        }

        public partial class AddToWatchLaterCommand
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public ImpressionEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("playlistEditEndpoint")]
            public AddToWatchLaterCommandPlaylistEditEndpoint PlaylistEditEndpoint { get; set; }
        }

        public partial class AddToWatchLaterCommandPlaylistEditEndpoint
        {
            [JsonPropertyName("playlistId")]
            public string PlaylistId { get; set; }

            [JsonPropertyName("actions")]
            public List<PurpleAction> Actions { get; set; }
        }

        public partial class PurpleAction
        {
            [JsonPropertyName("addedVideoId")]
            public string AddedVideoId { get; set; }

            [JsonPropertyName("action")]
            public string Action { get; set; }
        }

        public partial class GetSharePanelCommand
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public ImpressionEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("webPlayerShareEntityServiceEndpoint")]
            public WebPlayerShareEntityServiceEndpoint WebPlayerShareEntityServiceEndpoint { get; set; }
        }

        public partial class WebPlayerShareEntityServiceEndpoint
        {
            [JsonPropertyName("serializedShareEntity")]
            public string SerializedShareEntity { get; set; }
        }

        public partial class RemoveFromWatchLaterCommand
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public ImpressionEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("playlistEditEndpoint")]
            public RemoveFromWatchLaterCommandPlaylistEditEndpoint PlaylistEditEndpoint { get; set; }
        }

        public partial class RemoveFromWatchLaterCommandPlaylistEditEndpoint
        {
            [JsonPropertyName("playlistId")]
            public string PlaylistId { get; set; }

            [JsonPropertyName("actions")]
            public List<FluffyAction> Actions { get; set; }
        }

        public partial class FluffyAction
        {
            [JsonPropertyName("action")]
            public string Action { get; set; }

            [JsonPropertyName("removedVideoId")]
            public string RemovedVideoId { get; set; }
        }

        public partial class SubscribeCommand
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public ImpressionEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("subscribeEndpoint")]
            public SubscribeEndpoint SubscribeEndpoint { get; set; }
        }

        public partial class SubscribeEndpoint
        {
            [JsonPropertyName("channelIds")]
            public List<string> ChannelIds { get; set; }

            [JsonPropertyName("params")]
            public string Params { get; set; }
        }

        public partial class UnsubscribeCommand
        {
            [JsonPropertyName("clickTrackingParams")]
            public string ClickTrackingParams { get; set; }

            [JsonPropertyName("commandMetadata")]
            public ImpressionEndpointCommandMetadata CommandMetadata { get; set; }

            [JsonPropertyName("unsubscribeEndpoint")]
            public SubscribeEndpoint UnsubscribeEndpoint { get; set; }
        }

        public partial class ResponseContext
        {
            [JsonPropertyName("serviceTrackingParams")]
            public List<ServiceTrackingParam> ServiceTrackingParams { get; set; }

            [JsonPropertyName("webResponseContextExtensionData")]
            public WebResponseContextExtensionData WebResponseContextExtensionData { get; set; }
        }

        public partial class ServiceTrackingParam
        {
            [JsonPropertyName("service")]
            public string Service { get; set; }

            [JsonPropertyName("params")]
            public List<Param> Params { get; set; }
        }

        public partial class Param
        {
            [JsonPropertyName("key")]
            public string Key { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }

        public partial class WebResponseContextExtensionData
        {
            [JsonPropertyName("hasDecorated")]
            public bool? HasDecorated { get; set; }
        }

        public partial class Storyboards
        {
            [JsonPropertyName("playerStoryboardSpecRenderer")]
            public PlayerStoryboardSpecRenderer PlayerStoryboardSpecRenderer { get; set; }
        }

        public partial class PlayerStoryboardSpecRenderer
        {
            [JsonPropertyName("spec")]
            public Uri Spec { get; set; }
        }

        public partial class StreamingData
        {
            [JsonPropertyName("expiresInSeconds")]
            public string ExpiresInSeconds { get; set; }

            [JsonPropertyName("formats")]
            public List<Format> Formats { get; set; }

            [JsonPropertyName("adaptiveFormats")]
            public List<Format> AdaptiveFormats { get; set; }
        }

        public partial class Format
        {
            [JsonPropertyName("itag")]
            public long? Itag { get; set; }

            [JsonPropertyName("url")]
            public Uri Url { get; set; }

            [JsonPropertyName("mimeType")]
            public string MimeType { get; set; }

            [JsonPropertyName("bitrate")]
            public long? Bitrate { get; set; }

            [JsonPropertyName("width")]
            public long? Width { get; set; }

            [JsonPropertyName("height")]
            public long? Height { get; set; }

            [JsonPropertyName("initRange")]
            public Range InitRange { get; set; }

            [JsonPropertyName("indexRange")]
            public Range IndexRange { get; set; }

            [JsonPropertyName("lastModified")]
            public string LastModified { get; set; }

            [JsonPropertyName("contentLength")]
            public string ContentLength { get; set; }

            [JsonPropertyName("quality")]
            public string Quality { get; set; }

            [JsonPropertyName("fps")]
            public long? Fps { get; set; }

            [JsonPropertyName("qualityLabel")]
            public string QualityLabel { get; set; }

            [JsonPropertyName("projectionType")]
            public string ProjectionType { get; set; }

            [JsonPropertyName("averageBitrate")]
            public long? AverageBitrate { get; set; }

            [JsonPropertyName("approxDurationMs")]
            public string ApproxDurationMs { get; set; }

            [JsonPropertyName("colorInfo")]
            public ColorInfo ColorInfo { get; set; }

            [JsonPropertyName("highReplication")]
            public bool? HighReplication { get; set; }

            [JsonPropertyName("audioQuality")]
            public string AudioQuality { get; set; }

            [JsonPropertyName("audioSampleRate")]
            public string AudioSampleRate { get; set; }

            [JsonPropertyName("audioChannels")]
            public long? AudioChannels { get; set; }

            [JsonPropertyName("loudnessDb")]
            public double? LoudnessDb { get; set; }
        }

        public partial class ColorInfo
        {
            [JsonPropertyName("primaries")]
            public string Primaries { get; set; }

            [JsonPropertyName("transferCharacteristics")]
            public string TransferCharacteristics { get; set; }

            [JsonPropertyName("matrixCoefficients")]
            public string MatrixCoefficients { get; set; }
        }

        public partial class Range
        {
            [JsonPropertyName("start")]
            public string Start { get; set; }

            [JsonPropertyName("end")]
            public string End { get; set; }
        }

        public partial class VideoDetails
        {
            [JsonPropertyName("videoId")]
            public string VideoId { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("lengthSeconds")]
            public string LengthSeconds { get; set; }

            [JsonPropertyName("keywords")]
            public List<string> Keywords { get; set; }

            [JsonPropertyName("channelId")]
            public string ChannelId { get; set; }

            [JsonPropertyName("isOwnerViewing")]
            public bool? IsOwnerViewing { get; set; }

            [JsonPropertyName("shortDescription")]
            public string ShortDescription { get; set; }

            [JsonPropertyName("isCrawlable")]
            public bool? IsCrawlable { get; set; }

            [JsonPropertyName("thumbnail")]
            public HeaderBackgroundImageClass Thumbnail { get; set; }

            [JsonPropertyName("averageRating")]
            public double? AverageRating { get; set; }

            [JsonPropertyName("allowRatings")]
            public bool? AllowRatings { get; set; }

            [JsonPropertyName("viewCount")]
            public string ViewCount { get; set; }

            [JsonPropertyName("author")]
            public string Author { get; set; }

            [JsonPropertyName("isPrivate")]
            public bool? IsPrivate { get; set; }

            [JsonPropertyName("isUnpluggedCorpus")]
            public bool? IsUnpluggedCorpus { get; set; }

            [JsonPropertyName("isLiveContent")]
            public bool? IsLiveContent { get; set; }
        }

    }
}
