using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NNDD.Entities
{
    public class SessionJsonHLS
    {
        public SessionJsonHLS(WatchData data, string audio, string video)
        {
            var sessAPIData = data.Video.DmcInfo.SessionApi;
            var sessAPIUrl = sessAPIData.Urls.First();

            var authTypeProtocol = sessAPIData.Protocols.First();
            var authType = sessAPIData.AuthTypes.GetType().GetProperties().First(x => x.Name.ToLower() == authTypeProtocol).GetValue(sessAPIData.AuthTypes);

            this.SessionField.ClientInfo.PlayerId = sessAPIData.PlayerId;

            this.SessionField.ContentAuth.AuthType = authType.ToString();
            this.SessionField.ContentAuth.ContentKeyTimeout = sessAPIData.ContentKeyTimeout;
            this.SessionField.ContentAuth.ServiceId = "nicovideo";
            this.SessionField.ContentAuth.ServiceUserId = sessAPIData.ServiceUserId;

            this.SessionField.ContentId = sessAPIData.ContentId;
            var SRCID = new ContentSrcId();
            SRCID.SrcIdToMux.AudioSrcIds.Add(audio);
            SRCID.SrcIdToMux.VideoSrcIds.Add(video);
            var SRCIDs = new ContentSrcIdSet();
            SRCIDs.ContentSrcIds.Add(SRCID);
            this.SessionField.ContentSrcIdSets.Add(SRCIDs);

            this.SessionField.ContentType = "movie";
            this.SessionField.ContentUri = "";

            this.SessionField.KeepMethod.Heartbeat.Lifetime = sessAPIData.HeartbeatLifetime;

            this.SessionField.Priority = sessAPIData.Priority;

            this.SessionField.Protocol.Name = "http";
            this.SessionField.Protocol.Parameters.HttpParameters.Parameters.HttpOutputDownloadParameters.SegmentDuration = 6000;
            this.SessionField.Protocol.Parameters.HttpParameters.Parameters.HttpOutputDownloadParameters.TransferPreset = data.Video.DmcInfo.SessionApi.TransferPresets.First();
            this.SessionField.Protocol.Parameters.HttpParameters.Parameters.HttpOutputDownloadParameters.UseSsl = sessAPIUrl.IsSsl.Value ? "yes" : "no";
            this.SessionField.Protocol.Parameters.HttpParameters.Parameters.HttpOutputDownloadParameters.UseWellKnownPort = sessAPIUrl.IsWellKnownPort.Value ? "yes" : "no";

            this.SessionField.RecipeId = sessAPIData.RecipeId;

            this.SessionField.SessionOperationAuth.SessionOperationAuthBySignature.Signature = sessAPIData.Signature;
            this.SessionField.SessionOperationAuth.SessionOperationAuthBySignature.Token = sessAPIData.Token;

            this.SessionField.TimingConstraint = "unlimited";
        }


        [JsonPropertyName("session")]
        public Session SessionField { get; set; } = new Session();

        public partial class Session
        {
            [JsonPropertyName("client_info")]
            public ClientInfo ClientInfo { get; set; } = new ClientInfo();

            [JsonPropertyName("content_auth")]
            public ContentAuth ContentAuth { get; set; } = new ContentAuth();

            [JsonPropertyName("content_id")]
            public string ContentId { get; set; }

            [JsonPropertyName("content_src_id_sets")]
            public List<ContentSrcIdSet> ContentSrcIdSets { get; set; } = new List<ContentSrcIdSet>();

            [JsonPropertyName("content_type")]
            public string ContentType { get; set; }

            [JsonPropertyName("content_uri")]
            public string ContentUri { get; set; }

            [JsonPropertyName("keep_method")]
            public KeepMethod KeepMethod { get; set; } = new KeepMethod();

            [JsonPropertyName("priority")]
            public double? Priority { get; set; }

            [JsonPropertyName("protocol")]
            public Protocol Protocol { get; set; } = new Protocol();

            [JsonPropertyName("recipe_id")]
            public string RecipeId { get; set; }

            [JsonPropertyName("session_operation_auth")]
            public SessionOperationAuth SessionOperationAuth { get; set; } = new SessionOperationAuth();

            [JsonPropertyName("timing_constraint")]
            public string TimingConstraint { get; set; }
        }

        public partial class ClientInfo
        {
            [JsonPropertyName("player_id")]
            public string PlayerId { get; set; }
        }

        public partial class ContentAuth
        {
            [JsonPropertyName("auth_type")]
            public string AuthType { get; set; }

            [JsonPropertyName("content_key_timeout")]
            public long? ContentKeyTimeout { get; set; }

            [JsonPropertyName("service_id")]
            public string ServiceId { get; set; }

            [JsonPropertyName("service_user_id")]
            public string ServiceUserId { get; set; }
        }

        public partial class ContentSrcIdSet
        {
            [JsonPropertyName("content_src_ids")]
            public List<ContentSrcId> ContentSrcIds { get; set; } = new List<ContentSrcId>();
        }

        public partial class ContentSrcId
        {
            [JsonPropertyName("src_id_to_mux")]
            public SrcIdToMux SrcIdToMux { get; set; } = new SrcIdToMux();
        }

        public partial class SrcIdToMux
        {
            [JsonPropertyName("audio_src_ids")]
            public List<string> AudioSrcIds { get; set; } = new List<string>();

            [JsonPropertyName("video_src_ids")]
            public List<string> VideoSrcIds { get; set; } = new List<string>();
        }

        public partial class KeepMethod
        {
            [JsonPropertyName("heartbeat")]
            public Heartbeat Heartbeat { get; set; } = new Heartbeat();
        }

        public partial class Heartbeat
        {
            [JsonPropertyName("lifetime")]
            public long? Lifetime { get; set; }
        }

        public partial class Protocol
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("parameters")]
            public ProtocolParameters Parameters { get; set; } = new ProtocolParameters();
        }

        public partial class ProtocolParameters
        {
            [JsonPropertyName("http_parameters")]
            public HttpParameters HttpParameters { get; set; } = new HttpParameters();
        }

        public partial class HttpParameters
        {
            [JsonPropertyName("parameters")]
            public HttpParametersParameters Parameters { get; set; } = new HttpParametersParameters();
        }

        public partial class HttpParametersParameters
        {
            [JsonPropertyName("hls_parameters")]
            public HlsParameters HttpOutputDownloadParameters { get; set; } = new HlsParameters();
        }

        public partial class HlsParameters
        {
            [JsonPropertyName("segment_duration")]
            public long SegmentDuration { get; set; }

            [JsonPropertyName("transfer_preset")]
            public string TransferPreset { get; set; }

            [JsonPropertyName("use_ssl")]
            public string UseSsl { get; set; }

            [JsonPropertyName("use_well_known_port")]
            public string UseWellKnownPort { get; set; }
        }

        public partial class SessionOperationAuth
        {
            [JsonPropertyName("session_operation_auth_by_signature")]
            public SessionOperationAuthBySignature SessionOperationAuthBySignature { get; set; } = new SessionOperationAuthBySignature();
        }

        public partial class SessionOperationAuthBySignature
        {
            [JsonPropertyName("signature")]
            public string Signature { get; set; }

            [JsonPropertyName("token")]
            public string Token { get; set; }
        }
    }
}
