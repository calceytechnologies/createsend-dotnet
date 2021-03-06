﻿using System;
using System.Collections.Specialized;
using System.Globalization;

namespace createsend_dotnet
{
    public class JourneyEmail : CreateSendBase
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public string EmailID { get; set; }

        public JourneyEmail(AuthenticationDetails auth, string emailID)
            : base(auth)
        {
            EmailID = emailID;
        }

        public PagedCollection<JourneyEmailRecipient> Recipients()
        {
            return Recipients(1, 1000, "asc");
        }

        public PagedCollection<JourneyEmailRecipient> Recipients(
            int page,
            int pageSize,
            string orderDirection)
        {
            return Recipients("", page, pageSize, orderDirection);
        }

        public PagedCollection<JourneyEmailRecipient> Recipients(
            DateTime fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            return Recipients(ConvertDateTimeToString(fromDate), page, pageSize, orderDirection);
        }

        public PagedCollection<JourneyEmailRecipient> Recipients(
            string fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            var queryArguments = CreateQueryArguments(fromDate, page, pageSize, orderDirection);

            return HttpGet<PagedCollection<JourneyEmailRecipient>>(string.Format("/journeys/email/{0}/recipients.json", EmailID), queryArguments);
        }

        public PagedCollection<JourneyEmailOpenDetail> Opens()
        {
            return Opens(1, 1000, "asc");
        }

        public PagedCollection<JourneyEmailOpenDetail> Opens(
            int page,
            int pageSize,
            string orderDirection)
        {
            return Opens("", page, pageSize, orderDirection);
        }

        public PagedCollection<JourneyEmailOpenDetail> Opens(
            DateTime fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            return Opens(ConvertDateTimeToString(fromDate), page, pageSize, orderDirection);
        }

        private PagedCollection<JourneyEmailOpenDetail> Opens(
            string fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            var queryArguments = CreateQueryArguments(fromDate, page, pageSize, orderDirection);

            return HttpGet<PagedCollection<JourneyEmailOpenDetail>>(string.Format("/journeys/email/{0}/opens.json", EmailID), queryArguments);
        }

        public PagedCollection<JourneyEmailUnsubscribeDetail> Unsubscribes()
        {
            return Unsubscribes(1, 1000, "asc");
        }

        public PagedCollection<JourneyEmailUnsubscribeDetail> Unsubscribes(
            int page,
            int pageSize,
            string orderDirection)
        {
            return Unsubscribes("", page, pageSize, orderDirection);
        }

        public PagedCollection<JourneyEmailUnsubscribeDetail> Unsubscribes(
            DateTime fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            return Unsubscribes(ConvertDateTimeToString(fromDate), page, pageSize, orderDirection);
        }

        private PagedCollection<JourneyEmailUnsubscribeDetail> Unsubscribes(
            string fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            var queryArguments = CreateQueryArguments(fromDate, page, pageSize, orderDirection);

            return HttpGet<PagedCollection<JourneyEmailUnsubscribeDetail>>(string.Format("/journeys/email/{0}/unsubscribes.json", EmailID), queryArguments);
        }

        public PagedCollection<JourneyEmailClickDetail> Clicks()
        {
            return Clicks(1, 1000, "asc");
        }

        public PagedCollection<JourneyEmailClickDetail> Clicks(
            int page,
            int pageSize,
            string orderDirection)
        {
            return Clicks("", page, pageSize, orderDirection);
        }

        public PagedCollection<JourneyEmailClickDetail> Clicks(
            DateTime fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            return Clicks(ConvertDateTimeToString(fromDate), page, pageSize, orderDirection);
        }

        private PagedCollection<JourneyEmailClickDetail> Clicks(
            string fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            var queryArguments = CreateQueryArguments(fromDate, page, pageSize, orderDirection);

            return HttpGet<PagedCollection<JourneyEmailClickDetail>>(string.Format("/journeys/email/{0}/clicks.json", EmailID), queryArguments);
        }

        public PagedCollection<JourneyEmailBounceDetail> Bounces()
        {
            return Bounces(1, 1000, "asc");
        }

        public PagedCollection<JourneyEmailBounceDetail> Bounces(
            int page,
            int pageSize,
            string orderDirection)
        {
            return Bounces("", page, pageSize, orderDirection);
        }

        public PagedCollection<JourneyEmailBounceDetail> Bounces(
            DateTime fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            return Bounces(ConvertDateTimeToString(fromDate), page, pageSize, orderDirection);
        }

        private PagedCollection<JourneyEmailBounceDetail> Bounces(
            string fromDate,
            int page,
            int pageSize,
            string orderDirection)
        {
            var queryArguments = CreateQueryArguments(fromDate, page, pageSize, orderDirection);

            return HttpGet<PagedCollection<JourneyEmailBounceDetail>>(string.Format("/journeys/email/{0}/bounces.json", EmailID), queryArguments);
        }

        private string ConvertDateTimeToString(DateTime date)
        {
            return date.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }

        private static NameValueCollection CreateQueryArguments(string fromDate, int page, int pageSize, string orderDirection)
        {
            return new NameValueCollection
            {
                {"date", fromDate},
                {"page", page.ToString()},
                {"pagesize", pageSize.ToString()},
                {"orderdirection", orderDirection}
            };
        }
    }
}
