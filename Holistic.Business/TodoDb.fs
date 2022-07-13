namespace Holistic.Business

open Microsoft.Data.Sqlite
open Dapper
open Dapper.Contrib
open Dapper.Contrib.Extensions

module DbBasics =

    let [<Literal>] connectionString = @"Data Source=C:\devbox\Holistic\Holistic.Business\bin\Debug\net6.0\todo.sqlite"

    let createConn () = new SqliteConnection(connectionString)

    /// Maps a nullable record (or possibly other types) to option.
    let optionOfNullableRecord (record: 'T) : 'T option =
        match record |> box with
        | null -> None
        | _ -> Some record

    let querySingleOrDefault<'T> (conn: SqliteConnection, sql: string, args: obj) : 'T option =
        conn.QuerySingleOrDefault<'T> (sql, args) |> optionOfNullableRecord

    let getEntity<'T when 'T : not struct> (conn: SqliteConnection, id: obj) : 'T option =
        conn.Get<'T> id |> optionOfNullableRecord

[<Table "Todo"; CLIMutable>]
type EntTodo =
    {
        Id: int64
        Title: string
        Description: string option
    }

module EntTodo =

    let getAll () : EntTodo seq =
        let conn = DbBasics.createConn ()
        conn.GetAll<EntTodo> ()

    let get (id: int) : EntTodo option =
        let conn = DbBasics.createConn ()
        DbBasics.getEntity<EntTodo> (conn, id)

    let update (ent: EntTodo) : bool =
        let conn = DbBasics.createConn ()
        conn.Update<EntTodo> ent

    let insert (ent: EntTodo) : int64 =
        let conn = DbBasics.createConn ()
        conn.Insert<EntTodo> ent
