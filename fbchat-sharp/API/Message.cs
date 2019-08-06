﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace fbchat_sharp.API
{
    /// <summary>
    /// Used to specify the size of a sent emoji
    /// </summary>
    public enum EmojiSize
    {
        [Description("369239383222810")]
        LARGE,
        [Description("369239343222814")]
        MEDIUM,
        [Description("369239263222822")]
        SMALL
    }

    public class EmojiSizeMethods
    {
        public static EmojiSize? _from_tags(List<string> tags)
        {
            var string_to_emojisize = FB_Message_Constants.LIKES;
            foreach (string tag in tags)
            {
                var data = tag.Split(new char[] { ':' }, 2);
                if (data.Length > 1 && data[0] == "hot_emoji_size")
                    return string_to_emojisize[data[1]];
            }
            return null;
        }
    }

    /// <summary>
    /// Used to specify a message reaction
    /// </summary>
    public enum MessageReaction
    {
        [Description("❤")]
        HEART,
        [Description("😍")]
        LOVE,
        [Description("😆")]
        SMILE,
        [Description("😮")]
        WOW,
        [Description("😢")]
        SAD,
        [Description("😠")]
        ANGRY,
        [Description("👍")]
        YES,
        [Description("👎")]
        NO
    }

    /// <summary>
    /// 
    /// </summary>
    public class FB_Message_Constants
    {
        public static readonly Dictionary<string, EmojiSize> LIKES = new Dictionary<string, EmojiSize>() {
            { "large", EmojiSize.LARGE },
            { "medium", EmojiSize.MEDIUM },
            { "small", EmojiSize.SMALL },
            { "l", EmojiSize.LARGE },
            { "m", EmojiSize.MEDIUM },
            { "s", EmojiSize.SMALL }
        };

        public static readonly Dictionary<string, MessageReaction> REACTIONS = new Dictionary<string, MessageReaction>() {
            { "❤", MessageReaction.HEART },
            { "😍", MessageReaction.LOVE },
            { "😆", MessageReaction.SMILE },
            { "😮", MessageReaction.WOW },
            { "😢", MessageReaction.SAD },
            { "😠", MessageReaction.ANGRY },
            { "👍", MessageReaction.YES },
            { "👎", MessageReaction.NO }
        };
    }

    /// <summary>
    /// Facebook messenger mention class
    /// </summary>
    public class FB_Mention
    {
        /// The thread ID the mention is pointing at
        public string thread_id { get; set; }
        /// The character where the mention starts
        public int offset { get; set; }
        /// The length of the mention
        public int length { get; set; }

        /// <summary>
        /// Represents a @mention
        /// </summary>
        /// <param name="thread_id"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        public FB_Mention(string thread_id = null, int offset = 0, int length = 10)
        {
            this.thread_id = thread_id;
            this.offset = offset;
            this.length = length;
        }

        /// <returns>Pretty string representation of the thread</returns>
        public override string ToString()
        {
            return this.__unicode__();
        }

        private string __unicode__()
        {
            return string.Format("<Mention {0}: offset={1} length={2}>", this.thread_id, this.offset, this.length);
        }
    }

    /// <summary>
    /// Facebook messenger message class
    /// </summary>
    public class FB_Message
    {
        /// The actual message
        public string text { get; set; }
        /// A list of :class:`Mention` objects
        public List<FB_Mention> mentions { get; set; }
        /// A :class:`EmojiSize`. Size of a sent emoji
        public EmojiSize? emoji_size { get; set; }
        /// The message ID
        public string uid { get; set; }
        /// ID of the sender
        public string author { get; set; }
        /// Timestamp of when the message was sent
        public string timestamp { get; set; }
        /// Whether the message is read
        public bool is_read { get; set; }
        /// A list of pepole IDs who read the message, works only with :func:`fbchat-sharp.Client.fetchThreadMessages`
        public List<string> read_by { get; set; }
        /// A dict with user's IDs as keys, and their :class:`MessageReaction` as values
        public Dictionary<string, MessageReaction> reactions { get; set; }
        /// An ID of a sent sticker
        public FB_Sticker sticker { get; set; }
        /// A list of attachments
        public List<FB_Attachment> attachments { get; set; }
        /// A list of :class:`QuickReply`
        public List<FB_QuickReply> quick_replies { get; set; }
        /// Whether the message is unsent (deleted for everyone)
        public bool unsent { get; set; }
        /// Message ID you want to reply to
        public string reply_to_id { get; set; }
        /// Replied message
        public FB_Message replied_to { get; set; }
        /// Whether the message was forwarded
        public bool forwarded { get; set; }
        /// The message was sent from me (not filled)
        public bool is_from_me { get; set; }
        /// The thread this message belong to (not in fbchat)
        public string thread_id { get; set; }

        /// <summary>
        /// Facebook messenger message class
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mentions"></param>
        /// <param name="emoji_size"></param>
        /// <param name="uid"></param>
        /// <param name="author"></param>
        /// <param name="timestamp"></param>
        /// <param name="is_read"></param>
        /// <param name="read_by"></param>
        /// <param name="reactions"></param>
        /// <param name="sticker"></param>
        /// <param name="attachments"></param>
        /// <param name="quick_replies"></param>
        /// <param name="unsent"></param>
        /// <param name="reply_to_id"></param>
        /// <param name="replied_to"></param>
        /// <param name="forwarded"></param>
        /// <param name="is_from_me"></param>
        /// <param name="thread_id"></param>
        public FB_Message(string text = null, List<FB_Mention> mentions = null, EmojiSize? emoji_size = null, string uid = null, string author = null, string timestamp = null, bool is_read = false, List<string> read_by = null, Dictionary<string, MessageReaction> reactions = null, FB_Sticker sticker = null, List<FB_Attachment> attachments = null, List<FB_QuickReply> quick_replies = null, bool unsent = false, string reply_to_id = null, FB_Message replied_to = null, bool forwarded = false, bool is_from_me = false, string thread_id = null)
        {
            this.text = text;
            this.mentions = mentions ?? new List<FB_Mention>();
            this.emoji_size = emoji_size;
            this.uid = uid;
            this.author = author;
            this.timestamp = timestamp;
            this.is_read = is_read;
            this.read_by = read_by ?? new List<string>();
            this.reactions = reactions ?? new Dictionary<string, MessageReaction>();
            this.sticker = sticker;
            this.attachments = attachments ?? new List<FB_Attachment>();
            this.quick_replies = quick_replies ?? new List<FB_QuickReply>();
            this.unsent = unsent;
            this.reply_to_id = reply_to_id;
            this.replied_to = replied_to;
            this.forwarded = forwarded;
            this.is_from_me = is_from_me;
            this.thread_id = thread_id;
        }

        /// <returns>Pretty string representation of the thread</returns>
        public override string ToString()
        {
            return this.__unicode__();
        }

        private string __unicode__()
        {
            return string.Format("<Message ({0}): {1}, mentions={2} emoji_size={3} attachments={4}>", this.uid, this.text, this.mentions, this.emoji_size, this.attachments);
        }

        /// <summary>
        /// Like `str.format`, but takes tuples with a thread id and text instead.
        /// Returns a `Message` object, with the formatted string and relevant mentions.
        /// </summary>
        /// <param name="text"></param>
        public static FB_Message formatMentions(string text)
        {
            throw new NotImplementedException();
        }

        public static bool _get_forwarded_from_tags(List<string> tags)
        {
            if (tags == null)
                return false;
            return tags.Any((tag) => tag.Contains("forward") || tag.Contains("copy"));
        }

        public static FB_Message _from_graphql(JToken data, string thread_id)
        {
            if (data["message_sender"] == null || data["message_sender"].Type == JTokenType.Null)
                data["message_sender"] = new JObject(new JProperty("id", 0));
            if (data["message"] == null || data["message"].Type == JTokenType.Null)
                data["message"] = new JObject(new JProperty("text", ""));

            var tags = data["tags_list"]?.ToObject<List<string>>();

            var rtn = new FB_Message(
                text: data["message"]?["text"]?.Value<string>(),
                mentions: data["message"]?["ranges"]?.Select((m) => 
                    new FB_Mention(
                        thread_id: m["entity"]?["id"]?.Value<string>(),
                        offset: data["offset"]?.Value<int>() ?? 0,
                        length: data["length"]?.Value<int>() ?? 0)
                ).ToList(),
                emoji_size: EmojiSizeMethods._from_tags(tags),
                sticker: FB_Sticker._from_graphql(data["sticker"]));

            rtn.forwarded = FB_Message._get_forwarded_from_tags(tags);
            rtn.uid = data["message_id"]?.Value<string>();
            rtn.thread_id = thread_id; // Added
            rtn.author = data["message_sender"]?["id"]?.Value<string>();
            rtn.timestamp = data["timestamp_precise"]?.Value<string>();
            rtn.unsent = false;

            if (data["unread"] != null && data["unread"].Type != JTokenType.Null)
                rtn.is_read = !data["unread"].Value<bool>();
            rtn.reactions = new Dictionary<string, MessageReaction>();
            foreach (var r in data["message_reactions"])
            {
                rtn.reactions.Add(r["user"]?["id"]?.Value<string>(), FB_Message_Constants.REACTIONS[r["reaction"].Value<string>()]);
            }
            if (data["blob_attachments"] != null && data["blob_attachments"].Type != JTokenType.Null)
            {
                rtn.attachments = new List<FB_Attachment>();
                foreach (var attachment in data["blob_attachments"])
                {
                    rtn.attachments.Add(FB_Attachment.graphql_to_attachment(attachment));
                }
            }
            if (data["platform_xmd_encoded"] != null && data["platform_xmd_encoded"].Type != JTokenType.Null)
            {
                var quick_replies = JToken.Parse(data["platform_xmd_encoded"]?.Value<string>())["quick_replies"];
                if (quick_replies.Type == JTokenType.Array)
                    rtn.quick_replies = quick_replies.Select((q) => FB_QuickReply.graphql_to_quick_reply(q)).ToList();
                else
                    rtn.quick_replies = new List<FB_QuickReply>() { FB_QuickReply.graphql_to_quick_reply(quick_replies) };
            }
            if (data["extensible_attachment"] != null && data["extensible_attachment"].Type != JTokenType.Null)
            {
                var attachment = FB_Attachment.graphql_to_extensible_attachment(data["extensible_attachment"]);
                if (attachment is FB_UnsentMessage)
                    rtn.unsent = true;
                else if (attachment != null)
                {
                    rtn.attachments.Add(attachment);
                }
            }
            if (data["replied_to_message"] != null && data["replied_to_message"].Type != JTokenType.Null)
            {
                rtn.replied_to = FB_Message._from_graphql(data["replied_to_message"]["message"],thread_id);
                rtn.reply_to_id = rtn.replied_to.uid;
            }

            return rtn;
        }

        public static FB_Message _from_reply(JToken data, string thread_id)
        {
            var tags = data["messageMetadata"]?["tags"]?.ToObject<List<string>>();

            var rtn = new FB_Message(
                text: data["body"]?.Value<string>(),
                mentions: JToken.Parse(data["data"]?["prng"]?.Value<string>() ?? "{}")?.Select((m) =>
                    new FB_Mention(
                        thread_id: m["i"]?.Value<string>(),
                        offset: data["o"]?.Value<int>() ?? 0,
                        length: data["l"]?.Value<int>() ?? 0)
                ).ToList(),
                emoji_size: EmojiSizeMethods._from_tags(tags));

            var metadata = data["messageMetadata"];
            rtn.forwarded = FB_Message._get_forwarded_from_tags(tags);
            rtn.uid = metadata?["messageId"]?.Value<string>();
            rtn.thread_id = thread_id; // Added
            rtn.author = metadata?["actorFbId"]?.Value<string>();
            rtn.timestamp = metadata?["timestamp"]?.Value<string>();
            rtn.unsent = false;

            if (data["data"]?["platform_xmd"] != null && data["data"]?["platform_xmd"].Type != JTokenType.Null)
            {
                var quick_replies = JToken.Parse(data["data"]["platform_xmd"].Value<string>())["quick_replies"];
                if (quick_replies.Type == JTokenType.Array)
                    rtn.quick_replies = quick_replies.Select((q) => FB_QuickReply.graphql_to_quick_reply(q)).ToList();
                else
                    rtn.quick_replies = new List<FB_QuickReply>() { FB_QuickReply.graphql_to_quick_reply(quick_replies) };
            }
            if (data["attachments"] != null && data["attachments"].Type != JTokenType.Null)
            {
                foreach (var atc in data["attachments"]) {
                    var attachment = JToken.Parse(atc["mercuryJSON"]?.Value<string>());
                    if (attachment["blob_attachment"] != null && attachment["blob_attachment"].Type != JTokenType.Null)
                    {
                        rtn.attachments.Add(
                            FB_Attachment.graphql_to_attachment(attachment["blob_attachment"])
                        );
                    }
                    if (attachment["extensible_attachment"] != null && attachment["extensible_attachment"].Type != JTokenType.Null)
                    {
                        var ext_attachment = FB_Attachment.graphql_to_extensible_attachment(attachment["extensible_attachment"]);
                        if (ext_attachment is FB_UnsentMessage)
                            rtn.unsent = true;
                        else if (ext_attachment != null)
                        {
                            rtn.attachments.Add(ext_attachment);
                        }
                    }
                }
            }

            return rtn;
        }

        public static FB_Message _from_pull(JToken data, string thread_id, string mid= null, List<string> tags= null, string author= null, string timestamp= null)
        {
            var rtn = new FB_Message(
                text: data["body"]?.Value<string>());            
            rtn.uid = mid;
            rtn.thread_id = thread_id; // Added
            rtn.author = author;
            rtn.timestamp = timestamp;

            rtn.mentions = JToken.Parse(data["data"]?["prng"]?.Value<string>() ?? "{}")?.Select((m) =>
                    new FB_Mention(
                        thread_id: m["i"]?.Value<string>(),
                        offset: data["o"]?.Value<int>() ?? 0,
                        length: data["l"]?.Value<int>() ?? 0)
                ).ToList();

            if (data["attachments"] != null && data["attachments"].Type != JTokenType.Null)
            {
                try
                {
                    foreach (var a in data["attachments"])
                    {
                        var mercury = a["mercury"];
                        if (mercury["blob_attachment"] != null && mercury["blob_attachment"].Type != JTokenType.Null)
                        {
                            var image_metadata = a["imageMetadata"];
                            var attach_type = mercury["blob_attachment"]?["__typename"]?.Value<string>();
                            var attachment = FB_Attachment.graphql_to_attachment(
                                mercury["blob_attachment"]
                            );

                            if (new string[] { "MessageFile", "MessageVideo", "MessageAudio" }.Contains(attach_type)) {
                                // TODO: Add more data here for audio files
                                if (attachment is FB_FileAttachment)
                                    ((FB_FileAttachment)attachment).size = a?["fileSize"]?.Value<int>() ?? 0;
                                if (attachment is FB_VideoAttachment)
                                    ((FB_VideoAttachment)attachment).size = a?["fileSize"]?.Value<int>() ?? 0;
                            }
                            rtn.attachments.Add(attachment);
                        }
                        else if (mercury["sticker_attachment"] != null && mercury["sticker_attachment"].Type != JTokenType.Null)
                        {
                            rtn.sticker = FB_Sticker._from_graphql(
                                mercury["sticker_attachment"]
                            );
                        }
                        else if (mercury["extensible_attachment"] != null && mercury["extensible_attachment"].Type != JTokenType.Null)
                        {
                            var attachment = FB_Attachment.graphql_to_extensible_attachment(
                                mercury["extensible_attachment"]
                            );
                            if (attachment is FB_UnsentMessage)
                                rtn.unsent = true;
                            else if (attachment != null)
                                rtn.attachments.Add(attachment);
                        }
                    }
                }
                catch
                {
                    Debug.WriteLine(string.Format("An exception occured while reading attachments: {0}", data["attachments"]));
                }
            }

            rtn.emoji_size = EmojiSizeMethods._from_tags(tags);
            rtn.forwarded = FB_Message._get_forwarded_from_tags(tags);
            return rtn;
        }
    }
}
