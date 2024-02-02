-- +goose Up
CREATE TABLE cases (
      case_id varchar(50) NOT NULL,
      case_type varchar(50),
      court_name text,
      judge_name text,
      date timestamp without time zone,
      plaintiffs jsonb,
      respondents jsonb,
      PRIMARY KEY(case_id)
);
-- +goose StatementBegin

-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd
