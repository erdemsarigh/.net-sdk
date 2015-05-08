﻿namespace DreamFactory.Api.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;

    internal partial class DatabaseApi
    {
        public async Task<IEnumerable<TRecord>> CreateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = baseAddress.WithResource( tableName);
            address = address.WithSqlQuery(query);

            var recordsRequest = new { record = records.ToList() };
            string data = contentSerializer.Serialize(recordsRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Post, address.Build(), baseHeaders, data);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            return contentSerializer.Deserialize(response.Body, recordsRequest).record;
        }

        public async Task UpdateRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            IHttpAddress address = baseAddress.WithResource( tableName);

            var recordsRequest = new { record = records.ToList() };
            string data = contentSerializer.Serialize(recordsRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Patch, address.Build(), baseHeaders, data);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }

        public async Task<IEnumerable<TRecord>> GetRecordsAsync<TRecord>(string tableName, SqlQuery query)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IHttpAddress address = baseAddress.WithResource( tableName);
            address = address.WithSqlQuery(query);

            IHttpRequest request = new HttpRequest(HttpMethod.Get, address.Build(), baseHeaders);
            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);

            var recordSet = new { record = new List<TRecord>() };
            return contentSerializer.Deserialize(response.Body, recordSet).record;
        }

        public async Task DeleteRecordsAsync<TRecord>(string tableName, IEnumerable<TRecord> records)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }

            if (records == null)
            {
                throw new ArgumentNullException("records");
            }

            IHttpAddress address = baseAddress.WithResource( tableName);

            var recordsRequest = new { record = records.ToList() };
            string data = contentSerializer.Serialize(recordsRequest);
            IHttpRequest request = new HttpRequest(HttpMethod.Delete, address.Build(), baseHeaders, data);

            IHttpResponse response = await httpFacade.RequestAsync(request);
            HttpUtils.ThrowOnBadStatus(response, contentSerializer);
        }
    }
}
