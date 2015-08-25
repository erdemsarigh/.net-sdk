﻿namespace DreamFactory.Model.System.User
{
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.Role;
    using global::System;

    /// <summary>
    /// UserResponse.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Identifier of this user.
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// The email address required for this user.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// The set-able, but never readable, password.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// The first name for this user.
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// The last name for this user.
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Displayable name of this user.
        /// </summary>
        public string display_name { get; set; }

        /// <summary>
        /// Phone number for this user.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// True if this user is active for use.
        /// </summary>
        public bool? is_active { get; set; }

        /// <summary>
        /// True if this user is a system admin.
        /// </summary>
        public bool? is_sys_admin { get; set; }

        /// <summary>
        /// The default launched app for this user.
        /// </summary>
        public string default_app_id { get; set; }

        /// <summary>
        /// The role to which this user is assigned.
        /// </summary>
        public string role_id { get; set; }

        /// <summary>
        /// Related app by default_app_id.
        /// </summary>
        public RelatedApp default_app { get; set; }

        /// <summary>
        /// Related role by role_id.
        /// </summary>
        public RelatedRole role { get; set; }

        /// <summary>
        /// Date this user was created.
        /// </summary>
        public DateTime? created_date { get; set; }

        /// <summary>
        /// User Id of who created this user.
        /// </summary>
        public int? created_by_id { get; set; }

        /// <summary>
        /// Date this user was last modified.
        /// </summary>
        public DateTime? last_modified_date { get; set; }

        /// <summary>
        /// User Id of who last modified this user.
        /// </summary>
        public int? last_modified_by_id { get; set; }
    }
}
