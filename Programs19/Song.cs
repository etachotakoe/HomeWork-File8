﻿using System;

public class Song
{
    private string name; 
    private string author; 
    public Song prev; 

    public Song()
    {
        this.name = string.Empty;
        this.author = string.Empty;
        this.prev = null;
    }

    public Song(string name, string author)
    {
        this.name = name;
        this.author = author;
        this.prev = null;
    }

    public Song(string name, string author, Song prev)
    {
        this.name = name;
        this.author = author;
        this.prev = prev;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public void SetPrev(Song prev)
    {
        this.prev = prev;
    }

    public string Title()
    {
        return $"{name} - {author}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Song otherSong)
        {
            return this.name == otherSong.name && this.author == otherSong.author;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (name + author).GetHashCode();
    }
}
