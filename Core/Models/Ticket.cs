﻿using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }
        [Required]
        public int? ProjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Owner { get; set; }
        [Ticket_EnsureReportDatePresent]
        public DateTime? ReportDate { get; set; }
        [Ticket_EnsureFutureDueDateOnCreation]
        [Ticket_EnsureDueDatePresent]
        [Ticket_EnsureDueDateAfterReportDate]
        public DateTime? DueDate { get; set; }

        public Project Project { get; set; }

        // When creating a ticket, if due date is entered, it has to be in the future
        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate.Value > DateTime.Now);
        }

        // When owner is assigned, the report date has to be present
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return ReportDate.HasValue;
        }

        // When owner is assigned, the due date has to be present
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return DueDate.HasValue;
        }

        // When due date and report date are present, due date has to be later or equal to report
        public bool ValidateDueDateAfterReportDate()
        {
            if (!ReportDate.HasValue || !DueDate.HasValue) return true;

            return (DueDate.Value.Date >= ReportDate.Value.Date);
        }
    }
}
