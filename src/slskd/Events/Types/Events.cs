// <copyright file="Events.cs" company="slskd Team">
//     Copyright (c) slskd Team. All rights reserved.
//
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as published
//     by the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
//
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>

namespace slskd.Events;

using System;
using slskd.Transfers;

public abstract record Event
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public abstract EventType Type { get; }
}

public enum EventType
{
    None = 0,
    All = 1,
    DownloadFileComplete = 2,
    DownloadDirectoryComplete = 3,
}

public sealed record DownloadFileCompleteEvent : Event
{
    public override EventType Type => EventType.DownloadFileComplete;
    public string LocalFilename { get; init; }
    public string RemoteFilename { get; init; }
    public Transfer Transfer { get; init; }
}

public sealed record DownloadDirectoryCompleteEvent : Event
{
    public override EventType Type => EventType.DownloadDirectoryComplete;
    public string LocalDirectoryName { get; init; }
    public string RemoteDirectoryName { get; init; }
    public string Username { get; init; }
}