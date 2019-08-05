//-----------------------------------------------------------------------
// <copyright file="SocialApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using LoginRadiusSDK.V2.Models.ResponseModels.OtherObjects;
using LoginRadiusSDK.V2.Models.RequestModels;
using LoginRadiusSDK.V2.Models.ResponseModels.UserProfile;

namespace LoginRadiusSDK.V2.Api.Social
{
    public class SocialApi : LoginRadiusResource
    {
        /// <summary>
        /// This API Is used to translate the Request Token returned during authentication into an Access Token that can be used with other API calls.
        /// </summary>
        /// <param name="token">Token generated from a successful oauth from social platform</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.1

        public ApiResponse<AccessToken> ExchangeAccessToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(token));
            }
            var queryParameters = new QueryParameters
            {
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "token", token }
            };

            var resourcePath = "api/v2/access_token";
            
            return ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Refresh Access Token API is used to refresh the provider access token after authentication. It will be valid for up to 60 days on LoginRadius depending on the provider. In order to use the access token in other APIs, always refresh the token using this API.<br><br><b>Supported Providers :</b> Facebook,Yahoo,Google,Twitter, Linkedin.<br><br> Contact LoginRadius support team to enable this API.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="expiresIn">Allows you to specify a desired expiration time in minutes for the newly issued access_token.</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.2

        public ApiResponse<AccessToken> RefreshAccessToken(string accessToken, int? expiresIn = 0)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (expiresIn != null)
            {
               queryParameters.Add("expiresIn", expiresIn.ToString());
            }

            var resourcePath = "api/v2/access_token/refresh";
            
            return ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This API validates access token, if valid then returns a response with its expiry otherwise error.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition of Complete Token data</returns>
        /// 20.9

        public ApiResponse<AccessToken> ValidateAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/validate";
            
            return ConfigureAndExecute<AccessToken>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api invalidates the active access token or expires an access token validity.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response containing Definition for Complete Validation data</returns>
        /// 20.10

        public ApiResponse<PostMethodResponse> InValidateAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/invalidate";
            
            return ConfigureAndExecute<PostMethodResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api is use to get all active session by Access Token.
        /// </summary>
        /// <param name="token">Token generated from a successful oauth from social platform</param>
        /// <returns>Response containing Definition for Complete active sessions</returns>
        /// 20.11

        public ApiResponse<UserActiveSession> GetActiveSession(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(token));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] },
                { "token", token }
            };

            var resourcePath = "api/v2/access_token/activesession";
            
            return ConfigureAndExecute<UserActiveSession>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api is used to get all active sessions by AccountID(UID).
        /// </summary>
        /// <param name="accountId">UID, the unified identifier for each user account</param>
        /// <returns>Response containing Definition for Complete active sessions</returns>
        /// 20.12

        public ApiResponse<UserActiveSession> GetActiveSessionByAccountID(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accountId));
            }
            var queryParameters = new QueryParameters
            {
                { "accountId", accountId },
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/activesession";
            
            return ConfigureAndExecute<UserActiveSession>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// This api is used to get all active sessions by ProfileId.
        /// </summary>
        /// <param name="profileId">Social Provider Id</param>
        /// <returns>Response containing Definition for Complete active sessions</returns>
        /// 20.13

        public ApiResponse<UserActiveSession> GetActiveSessionByProfileID(string profileId)
        {
            if (string.IsNullOrWhiteSpace(profileId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(profileId));
            }
            var queryParameters = new QueryParameters
            {
                { "key", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "profileId", profileId },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/access_token/activesession";
            
            return ConfigureAndExecute<UserActiveSession>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// <b>Supported Providers:</b> Facebook, Google, Live, Vkontakte.<br><br> This API returns the photo albums associated with the passed in access tokens Social Profile.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Album Data</returns>
        /// 22.1

        public ApiResponse<List<Album>> GetAlbums(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/album";
            
            return ConfigureAndExecute<List<Album>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Audio API is used to get audio files data from the user’s social account.<br><br><b>Supported Providers:</b> Live, Vkontakte
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Audio Data</returns>
        /// 24.1

        public ApiResponse<List<Audio>> GetAudios(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/audio";
            
            return ConfigureAndExecute<List<Audio>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Check In API is used to get check Ins data from the user’s social account.<br><br><b>Supported Providers:</b> Facebook, Foursquare, Vkontakte
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of CheckIn Data</returns>
        /// 25.1

        public ApiResponse<List<CheckIn>> GetCheckIns(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/checkin";
            
            return ConfigureAndExecute<List<CheckIn>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Contact API is used to get contacts/friends/connections data from the user’s social account.This is one of the APIs that makes up the LoginRadius Friend Invite System. The data will normalized into LoginRadius’ standard data format. This API requires setting permissions in your LoginRadius Dashboard. <br><br><b>Note:</b> Facebook restricts access to the list of friends that is returned. When using the Contacts API with Facebook you will only receive friends that have accepted some permissions with your app. <br><br><b>Supported Providers:</b> Facebook, Foursquare, Google, LinkedIn, Live, Twitter, Vkontakte, Yahoo
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="nextCursor">Cursor value if not all contacts can be retrieved once.</param>
        /// <returns>Response containing Definition of Contact Data with Cursor</returns>
        /// 27.1

        public ApiResponse<CursorResponse<Contact>> GetContacts(string accessToken, string nextCursor = "")
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };
            if (!string.IsNullOrWhiteSpace(nextCursor))
            {
               queryParameters.Add("nextCursor", nextCursor);
            }

            var resourcePath = "api/v2/contact";
            
            return ConfigureAndExecute<CursorResponse<Contact>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Event API is used to get the event data from the user’s social account.<br><br><b>Supported Providers:</b> Facebook, Live
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Events Data</returns>
        /// 28.1

        public ApiResponse<List<Events>> GetEvents(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/event";
            
            return ConfigureAndExecute<List<Events>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// Get the following user list from the user’s social account.<br><br><b>Supported Providers:</b> Twitter
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Contacts Data</returns>
        /// 29.1

        public ApiResponse<List<Contact>> GetFollowings(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/following";
            
            return ConfigureAndExecute<List<Contact>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Group API is used to get group data from the user’s social account.<br><br><b>Supported Providers:</b> Facebook, Vkontakte
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Groups Data</returns>
        /// 30.1

        public ApiResponse<List<Group>> GetGroups(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/group";
            
            return ConfigureAndExecute<List<Group>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Like API is used to get likes data from the user’s social account.<br><br><b>Supported Providers:</b> Facebook
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Likes Data</returns>
        /// 31.1

        public ApiResponse<List<Like>> GetLikes(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/like";
            
            return ConfigureAndExecute<List<Like>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Mention API is used to get mentions data from the user’s social account.<br><br><b>Supported Providers:</b> Twitter
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Status Data</returns>
        /// 32.1

        public ApiResponse<List<Status>> GetMentions(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/mention";
            
            return ConfigureAndExecute<List<Status>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// Post Message API is used to post messages to the user’s contacts.<br><br><b>Supported Providers:</b> Twitter, LinkedIn <br><br>The Message API is used to post messages to the user’s contacts. This is one of the APIs that makes up the LoginRadius Friend Invite System. After using the Contact API, you can send messages to the retrieved contacts. This API requires setting permissions in your LoginRadius Dashboard.<br><br>GET & POST Message API work the same way except the API method is different
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="message">Body of your message</param>
        /// <param name="subject">Subject of your message</param>
        /// <param name="to">Recipient's social provider's id</param>
        /// <returns>Response containing Definition for Complete Validation data</returns>
        /// 33.1

        public ApiResponse<PostMethodResponse> PostMessage(string accessToken, string message,
        string subject, string to)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(message))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(message));
            }
            if (string.IsNullOrWhiteSpace(subject))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(subject));
            }
            if (string.IsNullOrWhiteSpace(to))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(to));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "message", message },
                { "subject", subject },
                { "to", to }
            };

            var resourcePath = "api/v2/message";
            
            return ConfigureAndExecute<PostMethodResponse>(HttpMethod.POST, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Page API is used to get the page data from the user’s social account.<br><br><b>Supported Providers:</b>  Facebook, LinkedIn
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="pageName">Name of the page you want to retrieve info from</param>
        /// <returns>Response containing Definition of Complete page data</returns>
        /// 34.1

        public ApiResponse<Page> GetPage(string accessToken, string pageName)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(pageName))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(pageName));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "pageName", pageName }
            };

            var resourcePath = "api/v2/page";
            
            return ConfigureAndExecute<Page>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Photo API is used to get photo data from the user’s social account.<br><br><b>Supported Providers:</b>  Facebook, Foursquare, Google, Live, Vkontakte
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="albumId">The id of the album you want to retrieve info from</param>
        /// <returns>Response Containing List of Photos Data</returns>
        /// 35.1

        public ApiResponse<List<Photo>> GetPhotos(string accessToken, string albumId)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(albumId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(albumId));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "albumId", albumId }
            };

            var resourcePath = "api/v2/photo";
            
            return ConfigureAndExecute<List<Photo>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Post API is used to get post message data from the user’s social account.<br><br><b>Supported Providers:</b>  Facebook
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Posts Data</returns>
        /// 36.1

        public ApiResponse<List<Post>> GetPosts(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/post";
            
            return ConfigureAndExecute<List<Post>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Status API is used to update the status on the user’s wall.<br><br><b>Supported Providers:</b>  Facebook, Twitter, LinkedIn
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="caption">Message displayed below the description(Requires URL, Under 70 Characters).</param>
        /// <param name="description">Description of the displayed URL and Image(Requires URL)</param>
        /// <param name="imageUrl">Image to be displayed in the share(Requires URL).</param>
        /// <param name="status">Main body of the Status update.</param>
        /// <param name="title">Title of Linked URL</param>
        /// <param name="url">URL to be included when clicking on the share.</param>
        /// <param name="shorturl">short url</param>
        /// <returns>Response conatining Definition of Validation and Short URL data</returns>
        /// 37.2

        public ApiResponse<PostMethodResponse<ShortUrlResponse>> StatusPosting(string accessToken, string caption,
        string description, string imageUrl, string status, string title, string url,
        string shorturl = "0")
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(caption))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(caption));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(description));
            }
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(imageUrl));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(status));
            }
            if (string.IsNullOrWhiteSpace(title))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(title));
            }
            if (string.IsNullOrWhiteSpace(url))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(url));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "caption", caption },
                { "description", description },
                { "imageurl", imageUrl },
                { "status", status },
                { "title", title },
                { "url", url }
            };
            if (!string.IsNullOrWhiteSpace(shorturl))
            {
               queryParameters.Add("shorturl", shorturl);
            }

            var resourcePath = "api/v2/status";
            
            return ConfigureAndExecute<PostMethodResponse<ShortUrlResponse>>(HttpMethod.POST, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Status API is used to get the status messages from the user’s social account.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <returns>Response Containing List of Status Data</returns>
        /// 37.3

        public ApiResponse<List<Status>> GetStatus(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/status";
            
            return ConfigureAndExecute<List<Status>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Trackable status API works very similar to the Status API but it returns a Post id that you can use to track the stats(shares, likes, comments) for a specific share/post/status update. This API requires setting permissions in your LoginRadius Dashboard.<br><br> The Trackable Status API is used to update the status on the user’s wall and return an Post ID value. It is commonly referred to as Permission based sharing or Push notifications.<br><br> POST Input Parameter Format: application/x-www-form-urlencoded
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="statusModel">Model Class containing Definition of payload for Status API</param>
        /// <returns>Response containing Definition for Complete status data</returns>
        /// 37.6

        public ApiResponse<StatusUpdateResponse> TrackableStatusPosting(string accessToken, StatusModel statusModel)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (statusModel == null)
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(statusModel));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };

            var resourcePath = "api/v2/status/trackable";
            
            return ConfigureAndExecute<StatusUpdateResponse>(HttpMethod.POST, resourcePath, queryParameters, ConvertToJson(statusModel));
        }
        /// <summary>
        /// The Trackable status API works very similar to the Status API but it returns a Post id that you can use to track the stats(shares, likes, comments) for a specific share/post/status update. This API requires setting permissions in your LoginRadius Dashboard.<br><br> The Trackable Status API is used to update the status on the user’s wall and return an Post ID value. It is commonly referred to as Permission based sharing or Push notifications.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="caption">Message displayed below the description(Requires URL, Under 70 Characters).</param>
        /// <param name="description">Description of the displayed URL and Image(Requires URL)</param>
        /// <param name="imageUrl">Image to be displayed in the share(Requires URL).</param>
        /// <param name="status">Main body of the Status update.</param>
        /// <param name="title">Title of Linked URL</param>
        /// <param name="url">URL to be included when clicking on the share.</param>
        /// <returns>Response containing Definition for Complete status data</returns>
        /// 37.7

        public ApiResponse<StatusUpdateResponse> GetTrackableStatusStats(string accessToken, string caption,
        string description, string imageUrl, string status, string title, string url)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(caption))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(caption));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(description));
            }
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(imageUrl));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(status));
            }
            if (string.IsNullOrWhiteSpace(title))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(title));
            }
            if (string.IsNullOrWhiteSpace(url))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(url));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "caption", caption },
                { "description", description },
                { "imageurl", imageUrl },
                { "status", status },
                { "title", title },
                { "url", url }
            };

            var resourcePath = "api/v2/status/trackable/js";
            
            return ConfigureAndExecute<StatusUpdateResponse>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Trackable status API works very similar to the Status API but it returns a Post id that you can use to track the stats(shares, likes, comments) for a specific share/post/status update. This API requires setting permissions in your LoginRadius Dashboard.<br><br> This API is used to retrieve a tracked post based on the passed in post ID value. This API requires setting permissions in your LoginRadius Dashboard.<br><br> <b>Note:</b> To utilize this API you need to find the ID for the post you want to track, which might require using Trackable Status Posting API first.
        /// </summary>
        /// <param name="postId">Post ID value</param>
        /// <returns>Response containing Definition of Complete Status Update data</returns>
        /// 37.8

        public ApiResponse<StatusUpdateStats> TrackableStatusFetching(string postId)
        {
            if (string.IsNullOrWhiteSpace(postId))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(postId));
            }
            var queryParameters = new QueryParameters
            {
                { "postId", postId },
                { "secret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };

            var resourcePath = "api/v2/status/trackable";
            
            return ConfigureAndExecute<StatusUpdateStats>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The User Profile API is used to get social profile data from the user’s social account after authentication.<br><br><b>Supported Providers:</b>  All
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete UserProfile data</returns>
        /// 38.1

        public ApiResponse<UserProfile> GetSocialUserProfile(string accessToken, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "api/v2/userprofile";
            
            return ConfigureAndExecute<UserProfile>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The User Profile API is used to get the latest updated social profile data from the user’s social account after authentication. The social profile will be retrieved via oAuth and OpenID protocols. The data is normalized into LoginRadius’ standard data format. This API should be called using the access token retrieved from the refresh access token API.
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="fields">The fields parameter filters the API response so that the response only includes a specific set of fields</param>
        /// <returns>Response containing Definition for Complete UserProfile data</returns>
        /// 38.2

        public ApiResponse<UserProfile> GetRefreshedSocialUserProfile(string accessToken, string fields = "")
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken }
            };
            if (!string.IsNullOrWhiteSpace(fields))
            {
               queryParameters.Add("fields", fields);
            }

            var resourcePath = "api/v2/userprofile/refresh";
            
            return ConfigureAndExecute<UserProfile>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
        /// <summary>
        /// The Video API is used to get video files data from the user’s social account.<br><br><b>Supported Providers:</b>   Facebook, Google, Live, Vkontakte
        /// </summary>
        /// <param name="accessToken">Uniquely generated identifier key by LoginRadius that is activated after successful authentication.</param>
        /// <param name="nextCursor">Cursor value if not all contacts can be retrieved once.</param>
        /// <returns>Response containing Definition of Video Data with Cursor</returns>
        /// 39.2

        public ApiResponse<CursorResponse<Video>> GetVideos(string accessToken, string nextCursor)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(accessToken));
            }
            if (string.IsNullOrWhiteSpace(nextCursor))
            {
               throw new ArgumentException(BaseConstants.ValidationMessage, nameof(nextCursor));
            }
            var queryParameters = new QueryParameters
            {
                { "access_token", accessToken },
                { "nextCursor", nextCursor }
            };

            var resourcePath = "api/v2/video";
            
            return ConfigureAndExecute<CursorResponse<Video>>(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}